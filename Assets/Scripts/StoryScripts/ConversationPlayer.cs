using ProxemicUIFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ConversationPlayer : MonoBehaviour
{
    [System.Serializable]
    public struct VoiceLine
    {
        public AudioClip voiceLine;
        public AudioSource voiceOrigin;
        public float beforeVoiceDelay;
        public float afterVoiceDelay;
        public VoiceVolumes volume;
    }

    public enum VoiceVolumes
    {
        Normal,
        Yelling,
        Whispering,
    }

    public static VoiceVolumes GetVoiceVolumes(string volume)
    {
        switch (volume)
        {
            case "Normal":
                return VoiceVolumes.Normal;
            case "Whisper":
                return VoiceVolumes.Whispering;
            case "Yell":
                return VoiceVolumes.Yelling;
            default:
                Debug.LogErrorFormat("ERROR '{0}' is not defined", volume);
                return VoiceVolumes.Normal;
        }
    }

    public bool IsConversationFinished { get { return _hasCompletedConversation; } }

    public bool isLoopConversation = true;
    public float LoopBufferTime = 5f; //The number of seconds to wait between looping from the last line to the first line
    public AudioClip OutOfRangeLoopClip;
    public StoryProxemicUIHost.OrRuleInfo ConversationInfo;
    public List<VoiceLine> ConversationLines = new List<VoiceLine>();
    public bool? eventIsTrue = null;
    public int AllAvatarsInConvo = 0;

    AudioSource _generalOutputSource;
    public bool _hasCompletedConversation = false;
    bool _playerInRangeFlag = false;
    public bool _isPlaying = false;
    public List<VoiceLine> _remainingLines;
    VoiceLine _currentVoiceLinePlaying;
    ORRule _rulesToTriggerConversation;
    ConversationNode _conversationNode;

    bool quitting = false;


    Transform VRPlayer;
    Transform ARPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        ARPlayer = GameObject.Find("MixedRealityPlayspace (1)").transform.GetChild(0);

        _generalOutputSource = GetComponent<AudioSource>();
        if (_generalOutputSource != null && OutOfRangeLoopClip != null)
        {
            _generalOutputSource.clip = OutOfRangeLoopClip;
            _generalOutputSource.Play();
        }

        _remainingLines = new List<VoiceLine>(ConversationLines);

        _conversationNode = GetComponent<ConversationNode>();

        CreateRule();
    }

    void CreateRule()
    {
        //Define as single OR rule!
        var defaultRule = ConversationInfo.DefaultRule;
        var proximityRule = ConversationInfo.ProximityRule;
        var facingRule = ConversationInfo.FacingRule;

        var defaultRule1 = defaultRule.FirstListEntities;
        var defaultRule2 = defaultRule.SecondListEntities;
        var proximityRule1 = proximityRule.FirstListEntities;
        var proximityRule2 = proximityRule.SecondListEntities;

        var facingRule1 = new List<Transform>();
        if (facingRule.Entity != null)
        {
            facingRule1 = new List<Transform> { facingRule.Entity };
        }

        if (DeploymentOption.DeploymentTypes.AR == DeploymentOption.Instance.DeploymentType)
        {
            // Triggers
            DeploymentOption.Instance.CheckEntity(defaultRule1, "VRPlayerController(Clone)");
            DeploymentOption.Instance.CheckEntity(defaultRule2, "VRPlayerController(Clone)");
            DeploymentOption.Instance.CheckEntity(proximityRule1, "VRPlayerController(Clone)");
            DeploymentOption.Instance.CheckEntity(proximityRule2, "VRPlayerController(Clone)");
            DeploymentOption.Instance.CheckEntity(facingRule1, "VRPlayerController(Clone)");

            // Audio Sources

        }
        else if (DeploymentOption.DeploymentTypes.VR == DeploymentOption.Instance.DeploymentType)
        {
            DeploymentOption.Instance.CheckEntity(defaultRule1, "Main Camera");
            DeploymentOption.Instance.CheckEntity(defaultRule2, "Main Camera");
            DeploymentOption.Instance.CheckEntity(proximityRule1, "Main Camera");
            DeploymentOption.Instance.CheckEntity(proximityRule2, "Main Camera");
            DeploymentOption.Instance.CheckEntity(facingRule1, "Main Camera");
        }

        ReplaceVRARAudioSource();
    }


    void ReplaceVRARAudioSource()
    {
        List<VoiceLine> newVoiceLines = new List<VoiceLine>();

        for (int i = 0; i < ConversationLines.Count; i++)
        {
            VoiceLine voiceLine = ConversationLines[i];
            AudioSource audioSource = voiceLine.voiceOrigin;

            if(DeploymentOption.DeploymentTypes.AR == DeploymentOption.Instance.DeploymentType && audioSource.name.Contains("VRPlayerController"))
            {
                audioSource = ARPlayer.GetComponent<AudioSource>();
            }

            voiceLine.voiceOrigin = audioSource;
            newVoiceLines.Add(voiceLine);
        }

        ConversationLines = newVoiceLines;

        _remainingLines = new List<VoiceLine>(newVoiceLines);
    }


    private void OnEnable()
    {
        Vector3 conversationNode = this.transform.position;
        ConversationInfo.FacingRule.ConversationCenter = new List<float> { conversationNode.x, conversationNode.y, conversationNode.z }; // in case author moved the conversation node
        _isPlaying = false;
        _hasCompletedConversation = false;
        eventIsTrue = null;
        if (_remainingLines.Count == 0)
        {
            _remainingLines = new List<VoiceLine>(ConversationLines);
        }

        _rulesToTriggerConversation = StoryProxemicUIHost.Instance.AddOrRule(ConversationInfo);

        _rulesToTriggerConversation.OnEventTrue += _rulesToTriggerConversation_OnEventTrue;
        _rulesToTriggerConversation.OnEventFalse += _rulesToTriggerConversation_OnEventFalse;
    }

    private void OnApplicationQuit()
    {
        quitting = true;
    }

    private void OnDisable()
    {
        if (quitting)
        {
            return;
        }
        _rulesToTriggerConversation = StoryProxemicUIHost.Instance.AddOrRule(ConversationInfo);

        _rulesToTriggerConversation.OnEventTrue -= _rulesToTriggerConversation_OnEventTrue;
        _rulesToTriggerConversation.OnEventFalse -= _rulesToTriggerConversation_OnEventFalse;
    }

    void Update()
    {
        //Repopulate remaining lines if conversation should loop (must have at least 1 line)
        if (isLoopConversation && _hasCompletedConversation)
        {
            _hasCompletedConversation = false;
            _remainingLines = new List<VoiceLine>(ConversationLines);
            //Add a buffer before looping
            var tempLine = _remainingLines[0];
            tempLine.beforeVoiceDelay += LoopBufferTime;
            _remainingLines[0] = tempLine;
        }
    }

    private void _rulesToTriggerConversation_OnEventFalse(Rules rule, ProximityEventArgs proximityEvent)
    {
        // This OnEventFalse has already ran
        if (!eventIsTrue.HasValue)
        {
            eventIsTrue = false;
        }
        else if (!eventIsTrue.Value)
        {
            return;
        }

        eventIsTrue = false;
        if (!_generalOutputSource.isPlaying)
        {
            _generalOutputSource?.Play();
        }

        //Cancel existing line if out of range
        if (_currentVoiceLinePlaying.voiceLine != null)
        {
            StopCurrentVoiceClip();
        }
    }

    private void _rulesToTriggerConversation_OnEventTrue(Rules rule, ProximityEventArgs proximityEvent)
    {
        string conversationName = this.gameObject.name;


        if (!this.enabled || (AllAvatarsInConvo != this.transform.childCount))
        {
            return;
        }
        eventIsTrue = true;
        if (!_isPlaying && !_hasCompletedConversation && _remainingLines.Count != 0)
        {
            _generalOutputSource?.Stop(); //stop general clip
            _currentVoiceLinePlaying = _remainingLines[0]; //continue conversation where it left off.
            BeforeVoiceLineDelay();
        }
    }

    public void InteruptConversation()
    {
        //Cancel existing line if interupted 
        if (_currentVoiceLinePlaying.voiceLine != null)
        {
            StopCurrentVoiceClip();
        }
    }

    bool doBeforeDelay = false;
    bool playVoiceLine = false;
    bool doAfterDelay = false;
    float _timeSinceStart = 0f;

    AvatarController[] avatarControllers = new AvatarController[0];

    private void FixedUpdate()
    {
        if (doBeforeDelay)
        {
            if (_timeSinceStart < _currentVoiceLinePlaying.beforeVoiceDelay)
            {
                _timeSinceStart += Time.deltaTime;
            }
            else
            {
                doBeforeDelay = false;
                _timeSinceStart = 0f;

                PlayVoiceLine();
            }
        }
        else if (playVoiceLine && !_currentVoiceLinePlaying.voiceOrigin.isPlaying)
        {
            playVoiceLine = false;

            //Done talking
            if (avatarControllers.Length > 0)
            {
                AvatarController avatar = _currentVoiceLinePlaying.voiceOrigin.transform.GetComponent<AvatarController>();
                avatar.SetConversationState(AvatarController.ConversationStates.None);
            }
            AfterVoiceLineDelay();
        }
        else if (doAfterDelay)
        {
            if(_timeSinceStart < _currentVoiceLinePlaying.afterVoiceDelay)
            {
                _timeSinceStart += Time.deltaTime;
            }
            else
            {
                doAfterDelay = false;
                _timeSinceStart = 0f;

                _isPlaying = false;
                DiscardLine(_currentVoiceLinePlaying); //May be problematic if async here?
            }
        }
    }

    void BeforeVoiceLineDelay()
    {
        _isPlaying = true;

        //Apply before voice delay
        doBeforeDelay = true;
    }

    void PlayVoiceLine()
    {
        //Apply voice volume
        switch (_currentVoiceLinePlaying.volume)
        {
            case (VoiceVolumes.Whispering):
                _currentVoiceLinePlaying.voiceOrigin.volume = 0.4f;
                break;
            case (VoiceVolumes.Normal):
                _currentVoiceLinePlaying.voiceOrigin.volume = 0.5f;
                break;
            case (VoiceVolumes.Yelling):
                _currentVoiceLinePlaying.voiceOrigin.volume = 0.6f;
                break;
        }

        _currentVoiceLinePlaying.voiceOrigin.clip = _currentVoiceLinePlaying.voiceLine;
        _currentVoiceLinePlaying.voiceOrigin.Play();

        avatarControllers = new AvatarController[0];
        if (_currentVoiceLinePlaying.voiceOrigin.transform.tag == "Avatar")
        {
            avatarControllers = _currentVoiceLinePlaying.voiceOrigin.transform.parent.GetComponentsInChildren<AvatarController>();
        }

        if (avatarControllers.Length > 0)
        {
            foreach (var avatarController in _currentVoiceLinePlaying.voiceOrigin.transform.parent.GetComponentsInChildren<AvatarController>())
            {
                avatarController.SetConversationState(AvatarController.ConversationStates.Listening);
            }

            AvatarController avatar = _currentVoiceLinePlaying.voiceOrigin.transform.GetComponent<AvatarController>();
            avatar.SetConversationState(AvatarController.ConversationStates.Talking);
        }

        playVoiceLine = true;
    }

    void AfterVoiceLineDelay()
    {
        doAfterDelay = true;
    }

    //Remove line from queue of remaining lines
    void DiscardLine(VoiceLine line)
    {
        _remainingLines.Remove(line);
        _currentVoiceLinePlaying.voiceLine = null;

        if (_remainingLines.Count == 0)
        {
            _hasCompletedConversation = true;
        }
    }

    void StopCurrentVoiceClip()
    {
        _remainingLines[0].voiceOrigin.Stop();

        if(_remainingLines[0].voiceOrigin.transform.tag == "Avatar")
        {
            var avatar = _remainingLines[0].voiceOrigin.transform.GetComponent<AvatarController>();
            avatar.SetConversationState(AvatarController.ConversationStates.None);
        }

        _isPlaying = false;
        _currentVoiceLinePlaying.voiceOrigin.Stop();
        _currentVoiceLinePlaying.voiceLine = null;
    }

}
