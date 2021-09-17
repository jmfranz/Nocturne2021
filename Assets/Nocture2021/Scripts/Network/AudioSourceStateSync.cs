using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

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
            stream.SendNext(_audioSource.volume); 
            stream.SendNext(_audioSource.clip.ToString().Split('(')[0].Trim());
        }
        else
        {
            var isPlaying = (bool) stream.ReceiveNext();
            if (isPlaying && !_audioSource.isPlaying)
            {
                _audioSource.volume = (float)stream.ReceiveNext();
                var audioSourceName = (string)stream.ReceiveNext();
                var audioClip = Resources.Load<AudioClip>($"Conversations/ConversationLines{audioSourceName}");
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
