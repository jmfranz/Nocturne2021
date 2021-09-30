using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    enum chaseStates { Chasing, Caught}
    chaseStates chaseState = chaseStates.Chasing;
    readonly float _caughtDistance = 1.25f; // larger than shadow stopping distance
    readonly float _shadowSenseDistance = 2.25f;

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
        OriginalParticleEffect();
        this.GetComponent<DirectIntroductionController>().enabled = false;
        this.GetComponent<ConversationPlayer>().enabled = false;
        shadow.parent.GetComponent<ConversationPlayer>()._remainingLines =  new List<ConversationPlayer.VoiceLine>();
    }

    void Update()
    {
        if (!Shadow.activeSelf)
        {
            return;
        }

        if ((IsFacingPlayer() || TooClose())) // Shadow follows player
        {
           if(chaseState == chaseStates.Chasing)
            {
                if (DeploymentOption.DeploymentTypes.VR == DeploymentOption.Instance.DeploymentType)
                {
                    shadowAvatarController.SetDestination(vrPlayer.position);
                }
                else if (DeploymentOption.DeploymentTypes.AR == DeploymentOption.Instance.DeploymentType)
                {
                    shadowAvatarController.SetDestination(arPlayer.position);
                    shadow.GetComponent<NavMeshAgent>().isStopped = false;
                }
            }

            float distance = 0;

            if (DeploymentOption.DeploymentTypes.VR == DeploymentOption.Instance.DeploymentType)
            {
                distance = Vector3.Distance(shadow.position, vrPlayer.position);
            }
            else if (DeploymentOption.DeploymentTypes.AR == DeploymentOption.Instance.DeploymentType)
            {
                distance = Vector2.Distance(new Vector2(shadow.position.x, shadow.position.z), new Vector2(arPlayer.position.x, arPlayer.position.z));
            }

            if (distance < _caughtDistance && !caughtPlayer) // Caught
            {
                caughtPlayer = true;
                chaseState = chaseStates.Caught;

                shadowAvatarController._movementState = AvatarController.MovementStates.Stopped;
                shadow.GetComponent<NavMeshAgent>().isStopped = true;
                shadow.GetComponent<AudioSource>().volume = 1f;

                // Make shadow particles big and scary
                ParticleSystem shadowParticles = Smoke.GetComponent<ParticleSystem>();
                shadowParticles.Stop();
                var main = shadowParticles.main;
                main.startSpeed = 7.36f;
                ParticleSystem.MinMaxCurve curve = new ParticleSystem.MinMaxCurve();
                curve.constantMin = 0.67f;
                curve.constantMax = 1.02f;
                main.startSize = curve;
                var emission = shadowParticles.emission;
                emission.rateOverTime = 177;
                shadowParticles.Play();
            }
            else if(distance >= (_caughtDistance + 0.25f) && chaseState == chaseStates.Caught) // Escaping
            {
                caughtPlayer = false;
                shadow.transform.GetChild(0).LookAt(arPlayer.transform);
                // Change particle system to normal
                //Vector3 location = _placesToGo[placesToGoIndex].transform.position;

                //if (TooClose())
                //{
                //    shadowAvatarController.SetDestination(arPlayer.position);
                //}
                //else
                //{
                //    shadowAvatarController.SetDestination(new Vector3(location.x, 0, location.z));
                //}

                shadow.GetComponent<NavMeshAgent>().speed = 0.3f;
                shadow.GetComponent<AudioSource>().volume = 0.5f;

                OriginalParticleEffect();

                //caughtPlayer = false;
                StartCoroutine(WaitForEscape());
            }
            followingPlayer = false;
        }
        else if(shadowAvatarController._movementState == AvatarController.MovementStates.Stopped) 
        {
            Vector3 location = _placesToGo[placesToGoIndex].transform.position;
            chaseState = chaseStates.Chasing;

            float distance = Vector2.Distance(new Vector2(shadow.position.x, shadow.position.z), new Vector2 (location.x, location.z));
            if (caughtPlayer)
            {
                caughtPlayer = false;
            }
            else if(distance < _caughtDistance)
            {
                placesToGoIndex++;
                if (placesToGoIndex == _placesToGo.Count) // Ran out of locations
                {
                    placesToGoIndex = 0;
                }
            }

            location = _placesToGo[placesToGoIndex].transform.position;
            shadowAvatarController.SetDestination(new Vector3(location.x, shadow.position.y, location.z));
        }
    }

    IEnumerator WaitForEscape()
    {
        yield return new WaitForSeconds(1);
        chaseState = chaseStates.Chasing;
    }

    IEnumerator DistractShadow()
    {
        yield return new WaitUntil(() => CaughtByShadowConversationPlayer._hasCompletedConversation);

        Vector3 location = _placesToGo[placesToGoIndex].transform.position;
        shadowAvatarController.SetDestination(new Vector3(location.x, 0, location.z));
    }

    bool TooClose()
    {
        return Vector2.Distance(new Vector2(shadow.position.x, shadow.position.z), new Vector2(arPlayer.position.x, arPlayer.position.z)) < _shadowSenseDistance;
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

    void OriginalParticleEffect()
    {
        ParticleSystem shadowParticles = Smoke.GetComponent<ParticleSystem>();
        shadowParticles.Stop();
        var main = shadowParticles.main;
        main.startSpeed = 0.039f;
        ParticleSystem.MinMaxCurve curve = new ParticleSystem.MinMaxCurve();
        curve.constantMin = 0.5f;
        curve.constantMax = 0.6f;
        main.startSize = curve;
        var emission = shadowParticles.emission;
        emission.rateOverTime = 120;
        shadowParticles.Play();
    }
}
