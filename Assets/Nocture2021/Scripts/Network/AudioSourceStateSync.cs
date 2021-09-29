using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Unity.Profiling;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceStateSync : MonoBehaviour, IPunObservable
{
    private AudioSource _audioSource;
    private bool hasPlayed14;
    private string _audioSourceFileName;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        hasPlayed14 = false;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (_audioSource == null)
        {
            return;
        }

        
        if (stream.IsWriting)
        {
            if (_audioSource.clip == null)
            {
                return;
            }

            var clip = _audioSource.clip;
            stream.SendNext(_audioSource.clip.ToString().Split('(')[0].Trim());
            stream.SendNext(_audioSource.isPlaying);
            stream.SendNext(_audioSource.volume);
            stream.SendNext(_audioSource.loop);
        }
        else
        {
   

            var audioSourceName = (string)stream.ReceiveNext();
            bool isPlaying = (bool)stream.ReceiveNext();
            float volume = (float)stream.ReceiveNext();
            bool loop = (bool)stream.ReceiveNext();

            if (gameObject.name == "Dog")
            {
                Debug.Log($"Source {audioSourceName}");
            }

            if (_audioSource == null)
            {
                Debug.Log($"GO {gameObject.name}, TR {audioSourceName}");
                return;
            }

            _audioSource.volume = volume;
            _audioSource.loop = loop;

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

                if (audioSourceName == "dog14")
                {
                    if (!hasPlayed14)
                    {
                        _audioSource.Play();
                        hasPlayed14 = true;
                    }

                    //Debug.Log($"dog 14: \n{isPlaying}\n{_audioSource.gameObject.name}\n{volume}");

                    return;
                }


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

    public void OnGUI()
    {
        if (gameObject.name == "Dog")
        {
            if (GUILayout.Button("Play dog source"))
            {
                _audioSource.Play();
            }
        }
    }
 
}
