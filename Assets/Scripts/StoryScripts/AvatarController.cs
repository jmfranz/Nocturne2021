using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class AvatarController : MonoBehaviour
{
    public enum ConversationStates
    {
        None,
        Talking,
        Listening,
    }

    public enum MovementTypes
    {
        Run,
        FastWalk,
        Walk,
    }

    public enum MovementStates
    {
        IsMoving,
        Stopped
    }

    const float LOOKINGROTATIONTHRESHOLD = 10f;

    public ConversationNode ActiveNode;
    public MovementStates MovementState { get { return _movementState; } }

    public NavMeshAgent _agent;
    ThirdPersonCharacter _character;
    public MovementStates _movementState;
    ConversationStates _conversationState;
    Animator _animator;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _character = GetComponent<ThirdPersonCharacter>();
        _animator = GetComponent<Animator>();
        _movementState = MovementStates.Stopped;
        _agent.updateRotation = false;
        _conversationState = ConversationStates.None;
    }


    void Update()
    {
        //Move towards destination
        if (_agent.remainingDistance >= _agent.stoppingDistance)
        {
            _character.Move(_agent.desiredVelocity, false, false);
            _movementState = MovementStates.IsMoving;
        }
        //Once reached destination, begin turning in spot until looking at prop
        else if (_movementState == MovementStates.IsMoving)
        {
            transform.LookAt(ActiveNode.LookAtPoint);

            transform.localEulerAngles = new Vector3(
                    0,
                    transform.localEulerAngles.y,
                    transform.localEulerAngles.z
                );

            _movementState = MovementStates.Stopped;
        }
        //Stop avatar movement
        else
        {
            _character.Move(Vector3.zero, false, false);
        }
    }


    public void GoToConversationNode(ConversationNode node, MovementTypes type)
    {
        //Determine how fast the avatar runs
        switch (type)
        {
            case MovementTypes.Run:
                _agent.speed = 0.9f;
                break;
            case MovementTypes.FastWalk:
                _agent.speed = 0.65f;
                break;
            case MovementTypes.Walk:
                _agent.speed = 0.5f;
                break;
        }

        ActiveNode?.RemoveAvatar(this.gameObject);
        Vector3 destination = node.AddAvatar(this.gameObject);
        ActiveNode = node;

        //SetDestination can only be called on an active agent that has been placed on a NavMesh.
        //Verification if _agent is enabled
        if (_agent.isActiveAndEnabled)
        {
            _agent.SetDestination(destination);
            _movementState = MovementStates.IsMoving;
        }
    }


    public void SetDestination(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }


    public void SetConversationState(ConversationStates state)
    {
        _conversationState = state;
        _animator.SetBool("Talking", state == ConversationStates.Talking);
    }
}
