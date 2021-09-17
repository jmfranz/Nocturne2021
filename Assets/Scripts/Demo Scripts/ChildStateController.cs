using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BIG NOTE: Currently the same as BystanderStateController unless we add more branches
 */
public class ChildStateController : MonoBehaviour
{
    [SerializeField] List<AudioClip> _state1Clips;
    [SerializeField] List<AudioClip> _state2Clips;

    AudioSource _audioSource;
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    public void OnApproach()
    {
        //Make body face player
        transform.LookAt(Camera.main.transform);

        //Reset height so avatar is not floating sideways
        transform.eulerAngles = new Vector3(
            0,
            transform.eulerAngles.y,
            transform.eulerAngles.z);

        //Play voice line
        if (StateController.CurrentState == StateController.States.Beginning)
        {
            _audioSource.clip = _state1Clips[Random.Range(0, _state1Clips.Count)];
        }
        else if (StateController.CurrentState == StateController.States.SearchingForKid)
        {
            _audioSource.clip = _state2Clips[Random.Range(0, _state2Clips.Count)];
        }
        else
        {
            return;
        }

        _audioSource.Play();
    }

    void Update()
    {
        if (_audioSource.isPlaying && !_animator.GetBool("Approached"))
        {
            _animator.SetBool("Approached", true);
        }
        else if (!_audioSource.isPlaying && _animator.GetBool("Approached"))
        {
            _animator.SetBool("Approached", false);
        }
    }
}
