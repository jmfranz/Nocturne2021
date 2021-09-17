using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowChaseController : MonoBehaviour
{
    [SerializeField] List<GameObject> _placesToGo;
    public GameObject VRPlayer, Shadow, ARPlayer;
    Transform shadow, vrPlayer, arPlayer;
    bool followingPlayer;
    bool caughtPlayer; 
    AvatarController shadowAvatarController;
    int placesToGoIndex;
    public GameObject ChaseConvos;

    public ConversationPlayer CaughtByShadowConversationPlayer;

    void Awake()
    {
        placesToGoIndex = 0;
        followingPlayer = false;
        caughtPlayer = false;
        shadow = Shadow.transform;
        //vrPlayer = VRPlayer.transform;
        arPlayer = ARPlayer.transform;
        shadowAvatarController = Shadow.GetComponent<AvatarController>();
    }

    private void OnEnable()
    {
        Shadow.SetActive(true);
        ChaseConvos.SetActive(true);
        shadowAvatarController.SetDestination(new Vector3(_placesToGo[placesToGoIndex].transform.position.x, 0, _placesToGo[placesToGoIndex].transform.position.z));
        this.GetComponent<DirectIntroductionController>().enabled = true;
    }

    private void OnDisable()
    {
        shadowAvatarController._movementState = AvatarController.MovementStates.Stopped;
        Shadow.SetActive(false);
        ChaseConvos.SetActive(false);
        this.GetComponent<DirectIntroductionController>().enabled = false;
    }

    void Update()
    {
        if (!Shadow.activeSelf)
        {
            return;
        }

        if ((IsFacingPlayer() || TooClose()) && !followingPlayer) // Change destination of shadow to follow player
        {
            followingPlayer = true;
            if (DeploymentOption.DeploymentTypes.VR == DeploymentOption.Instance.DeploymentType)
            {
                shadowAvatarController.SetDestination(vrPlayer.position);
            }
            else if (DeploymentOption.DeploymentTypes.AR == DeploymentOption.Instance.DeploymentType)
            {
                shadowAvatarController.SetDestination(arPlayer.position);
            }
        }
        else if (followingPlayer) // Not facing player anymore
        {
            float distance = 0;

            if (DeploymentOption.DeploymentTypes.VR == DeploymentOption.Instance.DeploymentType)
            {
                distance = Vector3.Distance(shadow.position, vrPlayer.position);
            }
            else if (DeploymentOption.DeploymentTypes.AR == DeploymentOption.Instance.DeploymentType)
            {
                distance = Vector3.Distance(shadow.position, arPlayer.position);
            }

            if (distance < 2f && !caughtPlayer)
            {
                caughtPlayer = true;

                //// Play Sound crash for where the shadow is going to next
                //List<ConversationPlayer.VoiceLine> convoLines = CaughtByShadowConversationPlayer.ConversationLines;

                //List<ConversationPlayer.VoiceLine> voiceLines = new List<ConversationPlayer.VoiceLine>();
                //ConversationPlayer.VoiceLine voiceLine = new ConversationPlayer.VoiceLine();
                //ConversationPlayer.VoiceLine voiceLine2 = new ConversationPlayer.VoiceLine();

                //voiceLine.voiceLine = convoLines[0].voiceLine;//Resources.Load<AudioClip>("Conversations/ConversationLines/DM_16");
                //voiceLine.voiceOrigin = convoLines[0].voiceOrigin;
                //voiceLine.volume = ConversationPlayer.VoiceVolumes.Normal;
                //voiceLine.beforeVoiceDelay = 0;
                //voiceLine.afterVoiceDelay = 0;

                //voiceLine2.voiceLine = convoLines[1].voiceLine;
                //voiceLine2.voiceOrigin = _placesToGo[placesToGoIndex].GetComponent<AudioSource>();
                //voiceLine2.volume = ConversationPlayer.VoiceVolumes.Normal;
                //voiceLine2.beforeVoiceDelay = 0;
                //voiceLine2.afterVoiceDelay = 0;

                //voiceLines.Add(voiceLine);
                //voiceLines.Add(voiceLine2);

                //CaughtByShadowConversationPlayer.ConversationLines = voiceLines;
                //CaughtByShadowConversationPlayer._remainingLines = voiceLines;

                //// Activate conversation
                //CaughtByShadowConversationPlayer.enabled = true;

                //StartCoroutine(DistractShadow());
                   // [1].voiceOrigin = _placesToGo[placesToGoIndex].GetComponent<AudioSource>();
                // TODO: Implement shadow caught player ending
                // Play Scary music for 5 seconds while still within a certain distance -> play bang -> shadow goes to other area
            }
            else
            {
                Vector3 location = _placesToGo[placesToGoIndex].transform.position;
                shadowAvatarController.SetDestination(new Vector3(location.x, 0, location.z));
            }
            followingPlayer = false;
        }
        else if(shadowAvatarController._movementState == AvatarController.MovementStates.Stopped) 
        {
            Vector3 location = _placesToGo[placesToGoIndex].transform.position;
            float distance = Vector3.Distance(shadow.position, new Vector3 (location.x, 0, location.z));
            if (caughtPlayer)
            {
                caughtPlayer = false;
            }
            else if(distance < 2)
            {
                placesToGoIndex++;
                if (placesToGoIndex == _placesToGo.Count) // Ran out of locations
                {
                    placesToGoIndex = 0;
                }
            }

            location = _placesToGo[placesToGoIndex].transform.position;
            shadowAvatarController.SetDestination(new Vector3(location.x, 0, location.z));
        }
    }

    IEnumerator DistractShadow()
    {
        yield return new WaitUntil(() => CaughtByShadowConversationPlayer._hasCompletedConversation);

        Vector3 location = _placesToGo[placesToGoIndex].transform.position;
        shadowAvatarController.SetDestination(new Vector3(location.x, 0, location.z));
    }

    bool TooClose()
    {
        return Vector3.Distance(arPlayer.position, shadow.position) < 3;
    }

    bool IsFacingPlayer()
    {
        Vector3 target = new Vector3();
        if(DeploymentOption.DeploymentTypes.VR == DeploymentOption.Instance.DeploymentType)
        {
            target = vrPlayer.position - shadow.position; // facing direction
        }
        else if(DeploymentOption.DeploymentTypes.AR == DeploymentOption.Instance.DeploymentType)
        {
            target = arPlayer.position - shadow.position; // facing direction
        }
        
        float angleToPlayer = Vector3.Angle(target, shadow.forward);
        return (angleToPlayer >= -60 && angleToPlayer <= 60) && PlayerIsVisible();
    }

    bool PlayerIsVisible()
    {
        RaycastHit hit;

        if(DeploymentOption.DeploymentTypes.VR == DeploymentOption.Instance.DeploymentType)
        {
            if (Physics.Raycast(shadow.position, (vrPlayer.position - shadow.position), out hit) && hit.transform == vrPlayer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (DeploymentOption.DeploymentTypes.AR == DeploymentOption.Instance.DeploymentType)
        {
            if (Physics.Raycast(shadow.position, (arPlayer.position - shadow.position), out hit) && hit.transform == arPlayer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;

    }
}
