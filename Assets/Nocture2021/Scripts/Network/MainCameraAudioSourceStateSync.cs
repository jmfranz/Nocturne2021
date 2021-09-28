using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(AudioSource))]
public class MainCameraAudioSourceStateSync : MonoBehaviour, IPunObservable
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
            if (_audioSource.clip != null)
            {
                stream.SendNext(_audioSource.clip.ToString().Split('(')[0].Trim());
            }
            else
            {
                stream.SendNext("no Audio");
            }

            stream.SendNext(_audioSource.loop);
        }
        else
        {
            GameObject otherPlayer = null;
            foreach (var go in GameObject.FindGameObjectsWithTag("PlayerRepresentation"))
            {
                var view = go.GetComponent<PhotonView>();
                if (!view.IsMine)
                {
                    otherPlayer = go;
                    break;
                }
            }

            var isPlaying = (bool) stream.ReceiveNext();
            if (isPlaying && !otherPlayer.GetComponent<AudioSource>().isPlaying)
            {
                otherPlayer.GetComponent<AudioSource>().volume = (float)stream.ReceiveNext();
                var audioSourceName = (string)stream.ReceiveNext();
                var audioClip = Resources.Load<AudioClip>($"Conversations/All Audio/{audioSourceName}");
                otherPlayer.GetComponent<AudioSource>().loop = (bool) stream.ReceiveNext();
                otherPlayer.GetComponent<AudioSource>().clip = audioClip;
                otherPlayer.GetComponent<AudioSource>().Play();
            }
            else if (!isPlaying && _audioSource.isPlaying)
            {
                otherPlayer.GetComponent<AudioSource>().Stop();
            }
        }
    }
 
}
