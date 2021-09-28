using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherStateController : MonoBehaviour
{
    [SerializeField] List<AudioClip> _state1Clips;
    [SerializeField] AudioClip _state1to2Clip;
    [SerializeField] AudioClip _state2Clip;

    AudioSource _audioSource;
    Animator _animator;

    const float _delay = 3; //in seconds

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();

        _audioSource.clip = _state1Clips[Random.Range(0, _state1Clips.Count)];
        _audioSource.PlayDelayed(_delay);

        _audioSource.maxDistance = 15;
    }

    private void Update()
    {
        //Make avatar look at player if talking to them
        if(StateController.CurrentState == StateController.States.TalkingToDad)
        {
            //Make body face player
            transform.LookAt(Camera.main.transform);

            //Reset height so avatar is not floating sideways
            transform.eulerAngles = new Vector3(
                0,
                transform.eulerAngles.y,
                transform.eulerAngles.z);
        }

        if (_audioSource.isPlaying)
        {
            return;
        }

        //Transition to State 2 once voice clip is finished
        if(StateController.CurrentState == StateController.States.TalkingToDad)
        {
            StateController.CurrentState = StateController.States.SearchingForKid;
            _audioSource.clip = _state2Clip;
            _animator.SetBool("FinishedInstructions", true);
            _audioSource.Play();
            return;
        }

        //Play looping audio clip according to state
        if (StateController.CurrentState == StateController.States.Beginning)
        {
            _audioSource.clip = _state1Clips[Random.Range(0, _state1Clips.Count)];
        }

        //Do not play anything if state is finished
        if(StateController.CurrentState == StateController.States.Finished)
        {
            return;
        }

        _audioSource.PlayDelayed(_delay);
    }

    public void OnApproach()
    {
        if(StateController.CurrentState == StateController.States.Beginning)
        {
            _animator.SetBool("Approached", true);
            _audioSource.clip = _state1to2Clip;
            _audioSource.Play();
            StateController.CurrentState = StateController.States.TalkingToDad;
            _audioSource.maxDistance = 5;
        }
    }
}
