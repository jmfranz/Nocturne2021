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

            if(_audioSource == null)
            {
                return;
            }

            var clip = _audioSource.clip;
            if (clip != null)
            {
                stream.SendNext(_audioSource.clip.ToString().Split('(')[0].Trim());
            }
            else
            {
                stream.SendNext("no Audio");
            }

            stream.SendNext(_audioSource.isPlaying);
            stream.SendNext(_audioSource.volume);
            stream.SendNext(_audioSource.loop);
        }
        else
        {
            var audioSourceName = (string)stream.ReceiveNext();
            bool isPlaying = (bool)stream.ReceiveNext();
            _audioSource.volume = (float)stream.ReceiveNext();
            _audioSource.loop = (bool)stream.ReceiveNext();

            if (audioSourceName == "no Audio")
            {
                _audioSource?.Stop();
            }
            else // It has an audio clip in the source
            {
                var audioClip = Resources.Load<AudioClip>($"Conversations/All Audio/{audioSourceName}");

                if (audioClip == null)
                {
                    Debug.Log($"Could not find {audioSourceName}");
                }

                _audioSource.clip = audioClip;


                if (isPlaying)
                {
                    _audioSource.Play();
                }
                else
                {
                    _audioSource.Stop();
                }
            }
        }
    }
 
}
