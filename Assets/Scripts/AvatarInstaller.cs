using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class AvatarInstaller : MonoBehaviour
{
    public static RuntimeAnimatorController Controller;
    public RuntimeAnimatorController ControllerToAssign;

    void Start()
    {
        //Really gross way of maintaining a set controller across componenets being deleted/created
        if(Controller == null)
        {
            Controller = ControllerToAssign;
        }
    }

    public static GameObject InstantiateAvatar(string avatarPath)
    {
        GameObject obj = Instantiate(Resources.Load(avatarPath) as GameObject);

        // Set up for allowing it to be part of a conversation
        obj.AddComponent<AvatarController>();
        obj.AddComponent<AudioSource>();
        obj.AddComponent<NavMeshAgent>();
        obj.AddComponent<ThirdPersonCharacter>();
        obj.GetComponent<Animator>().runtimeAnimatorController = Controller;
        obj.AddComponent<VirtualProxemicTracker>();
        
        var capCol = obj.GetComponent<CapsuleCollider>();
        capCol.height = 2;
        capCol.radius = 0.25f;
        capCol.center = new Vector3(0, 1, 0);

        var agent = obj.GetComponent<NavMeshAgent>();
        agent.acceleration = 3;
        agent.stoppingDistance = 0.2f;
        agent.speed = 0.5f;

        return obj;
    }
}
