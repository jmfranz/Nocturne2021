using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowChaseController : MonoBehaviour
{
    [SerializeField] List<GameObject> _placesToGo;
    public GameObject VRPlayer, Shadow, ARPlayer, Smoke;
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

                shadowAvatarController._movementState = AvatarController.MovementStates.Stopped;
                ParticleSystem shadowParticles = Smoke.GetComponent<ParticleSystem>();

                shadowParticles.
                //caughtPlayer = true;
                //TODO: Make shadow particle effect big and scary
                // Start speed: 7:36
                // Start Size: 0:67 - 1.02
                // Emission: rate over time: 177
            }
            else // Go to next location
            {
                // Change particle system to normal

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
