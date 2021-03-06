using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogMovementController : MonoBehaviour
{
    NavMeshAgent dogNavMeshAgent;
    DogAnimController dogAnimController;

    readonly float DOG_SPEED = 2f;

    public enum DogStates { ToLastRoom, ToMainRoom }
    public DogStates DogState = DogStates.ToLastRoom;

    public ConditionalEventComponent ConditionalMadeItToMidPoint1;
    public ConditionalEventComponent ConditionalMadeItToMidPoint2;
    public ConditionalEventComponent MadeItToMainRoom;
    public DialogueEventComponent MidPointConversation;
    public DialogueEventComponent MidPointConvoToMainRoom;
    public ConditionalEventComponent ConditionalMadeItToLastRoom;

    [SerializeField] Transform _midPointLoc;
    [SerializeField] Transform _lastRoomLoc;
    [SerializeField] Transform _mainRoomLoc;


    void Awake()
    {
        dogNavMeshAgent = this.GetComponent<NavMeshAgent>();
        dogAnimController = this.GetComponent<DogAnimController>();
    }

    private void Start()
    {
        MidPointConversation.OnEventEnd += GoToLastRoom;
        MidPointConvoToMainRoom.OnEventEnd += GoToMainRoom;
    }

    private void OnEnable()
    {
        GoToMidPoint();
      
    }
   
    bool walkToMidPoint = false;
    void GoToMidPoint()
    {
        dogAnimController.DogAnimState = DogAnimController.DogAnimStates.Move;
        dogNavMeshAgent.speed = DOG_SPEED;
        dogNavMeshAgent.SetDestination(new Vector3(_midPointLoc.position.x, 0, _midPointLoc.position.z)); // mid point between dog's room and last room
        walkToMidPoint = true;

    }

    bool goingToLastRoom = false;
    void GoToLastRoom()
    {
        dogAnimController.DogAnimState = DogAnimController.DogAnimStates.Move;
        dogNavMeshAgent.SetDestination(new Vector3(_lastRoomLoc.position.x, 0, _lastRoomLoc.position.z));
        dogNavMeshAgent.speed = DOG_SPEED;
        goingToLastRoom = true;

    }

    bool goingToMainRoom;
    void GoToMainRoom()
    {
        dogAnimController.DogAnimState = DogAnimController.DogAnimStates.Move;
        dogNavMeshAgent.SetDestination(new Vector3(_mainRoomLoc.position.x, 0, _mainRoomLoc.position.z));
        dogNavMeshAgent.speed = DOG_SPEED;
        goingToMainRoom = true;

    }

    
    void LateUpdate()
    {

        if (!dogNavMeshAgent.pathPending && dogNavMeshAgent.remainingDistance < dogNavMeshAgent.stoppingDistance) // Stop Dog Movement
        {


            if (walkToMidPoint && DogState == DogStates.ToLastRoom) // Between dog's room and last room
            {
                walkToMidPoint = false;
                dogAnimController.DogAnimState = DogAnimController.DogAnimStates.Sniff;
                ConditionalMadeItToMidPoint1.CompleteConditionalEvent();

                DogState = DogStates.ToMainRoom;
            }
            else if(walkToMidPoint && DogState == DogStates.ToMainRoom)
            {
                walkToMidPoint = false;
                ConditionalMadeItToMidPoint2.CompleteConditionalEvent();
            }

            if (goingToLastRoom)
            {
                goingToLastRoom = false;
                ConditionalMadeItToLastRoom.CompleteConditionalEvent();               
                transform.localRotation = Quaternion.Euler(0,120,0);
                enabled = false;
            }

            if (goingToMainRoom)
            {
                goingToMainRoom = false;
                MadeItToMainRoom.CompleteConditionalEvent();
                transform.localRotation = Quaternion.Euler(0, 180, 0); 
                enabled = false;
            }

            dogNavMeshAgent.speed = 0;
            dogAnimController.DogAnimState = DogAnimController.DogAnimStates.Idle;
        }
    }
}
