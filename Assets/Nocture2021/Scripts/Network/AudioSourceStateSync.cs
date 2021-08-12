using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceStateSync : MonoBehaviour, IPunObservable
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_audioSource.isPlaying);
        }
        else
        {
            var isPlaying = (bool) stream.ReceiveNext();
            if (isPlaying && !_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
            else if (!isPlaying && _audioSource.isPlaying)
            {
                _audioSource.Stop();
            }
        }
    }
 
}
