using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCtoFollowPlayer : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject Player;

    public bool FollowPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FollowPlayer)
        {
            agent.SetDestination(Player.transform.position);
        }
    }
}
