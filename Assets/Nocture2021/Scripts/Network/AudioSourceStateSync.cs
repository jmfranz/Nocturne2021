using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceStateSync : MonoBehaviour, IPunObservable
{
    private AudioSource _audioSource;

    private string _audioSourceFileName;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_audioSource.isPlaying);
            Debug.Log(_audioSource.isPlaying);
            stream.SendNext(_audioSource.volume); 
            stream.SendNext(_audioSource.clip.ToString().Split('(')[0].Trim());
            stream.SendNext(_audioSource.loop);
        }
        else
        {
            var isPlaying = (bool) stream.ReceiveNext();
            if (isPlaying && !_audioSource.isPlaying)
            {
                _audioSource.volume = (float)stream.ReceiveNext();
                var audioSourceName = (string)stream.ReceiveNext();
                var audioClip = Resources.Load<AudioClip>(audioSourceName);
                _audioSource.loop = (bool) stream.ReceiveNext();
                _audioSource.clip = audioClip;
                _audioSource.Play();
            }
            else if (!isPlaying && _audioSource.isPlaying)
            {
                _audioSource.Stop();
            }
        }
    }
 
}
