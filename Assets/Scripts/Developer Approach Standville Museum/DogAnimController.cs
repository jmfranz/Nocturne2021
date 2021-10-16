using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Adapted from the DogCollieFull_Controller
public class DogAnimController : MonoBehaviour
{
    public enum DogAnimStates { Talking, Move, Idle, Sniff, Attack, Sit }
    public DogAnimStates DogAnimState = DogAnimStates.Idle;

    [Range(0, 10)]
    public float multiplier = 1;

    float H, V;
    float horiz = 0f, vertic = 0f;

    float thisDir, yRotCurr; //positive = right, negative = left

    Animator anim;

    bool isTalking = false;
    
    void Awake()
    {
        anim = this.GetComponent<Animator>();
        yRotCurr = this.GetComponent<Transform>().rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorBasicController();
    }

    private void LateUpdate()
    {
        if (anim.GetBool("talk") && PlayerIsVisible())
        {
            transform.LookAt(Camera.main.transform);
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        }
    }

    void AnimatorBasicController()
    {
        anim.SetInteger("IDAnim", 0);
        anim.SetBool("attack", false);
        anim.SetBool("damage", false);
        anim.SetBool("death", false);
        anim.SetBool("hate", false);
        anim.SetBool("eat", false);
        anim.SetBool("drink", false);

        if (DogAnimState == DogAnimStates.Move)
        {
            BasicMovement();
        }
        else if(DogAnimState == DogAnimStates.Idle)
        {
            V = 0f;
            H = 0f;
            IdleStation();
        }

        if (DogAnimState == DogAnimStates.Sniff)
        {
            V = 0f;
            H = 0f;
            Sniffing();
        }

        if(DogAnimState == DogAnimStates.Talking)
        {
            DogStartTalking();
        }

        if(DogAnimState == DogAnimStates.Attack)
        {
            V = 0f;
            H = 0f;
            Aggression();
        }

        if (DogAnimState == DogAnimStates.Sit)
        {
            V = 0f;
            H = 0f;
            Sit();
        }

        if (horiz < H)
        {
            horiz = horiz + 0.04f;
            if (horiz >= H)
            {
                horiz = H;
            }
        }
        if (horiz > H)
        {
            horiz = horiz - 0.04f;
            if (horiz <= H)
            {
                horiz = H;
            }
        }
        if (vertic < V)
        {
            vertic = vertic + 0.02f;
            if (vertic >= V)
            {
                vertic = V;
            }
        }
        if (vertic > V)
        {
            vertic = vertic - 0.02f;
            if (vertic <= V)
            {
                vertic = V;
            }
        }
    }

    void BasicMovement()
    {
        anim.SetBool("idle", false);
        anim.SetBool("sleep", false);

        thisDir = this.GetComponent<Transform>().rotation.y;

        Vector3 nextPos = this.GetComponent<NavMeshAgent>().nextPosition;
        Vector3 targetDir = this.GetComponent<Transform>().position - nextPos;

        float angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);

        // Move forward
        V = 2f;

        // Move Left
        if (angle < 0)
        {
            H = -1f;
        }
        // Move Right
        else if (angle > 0)
        {
            H = 1f;
        }
        // Don't Turn
        else
        {
            H = 0f;
        }

        H = H * multiplier * Mathf.Abs(angle) / 360f;

        yRotCurr = thisDir;

        anim.SetBool("walk", true);
        anim.SetBool("idle", false);
        anim.SetBool("jump", false);
        anim.SetBool("talk", false);
        anim.SetBool("sniff", false);
        anim.SetFloat("Hor", horiz);
        anim.SetFloat("Vert", vertic);
        anim.SetBool("sit", false);
    }

    void DogStartTalking()
    {
        if (anim.GetBool("talk"))
        {
            return;
        }

        float forwardSpeed = Random.Range(0.5f, 1.5f);
        float backwardSpeed = Random.Range(0.5f, 1.5f);

        anim.SetFloat("Backwards Speed", forwardSpeed);
        anim.SetFloat("Forwards Speed", backwardSpeed);

        anim.SetBool("talk", true);
        anim.SetBool("idle", false);
        anim.SetBool("sniff", false);
        anim.SetBool("sit", false);
    }

    bool PlayerIsVisible()
    {
        RaycastHit hit;

        Vector3 dogPos = transform.position;

        if (!PhotonNetwork.IsMasterClient)
        {
            return false;
        }

        if (Physics.Raycast(new Vector3(dogPos.x, dogPos.y + 1, dogPos.z), (Camera.main.transform.position - dogPos), out hit) && hit.transform == Camera.main.transform)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void IdleStation()
    {
        int ID = Random.Range(0, 2);
        anim.SetInteger("IDAnim2", ID);

        anim.SetFloat("Hor", horiz);
        anim.SetFloat("Vert", vertic);
        anim.SetBool("idle", true);
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        anim.SetBool("talk", false);
        anim.SetBool("sniff", false);
        anim.SetBool("sit", false);
    }

    void Sniffing()
    {
        anim.SetFloat("Hor", horiz);
        anim.SetFloat("Vert", vertic);
        anim.SetBool("idle", false);
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        anim.SetBool("talk", false);
        anim.SetBool("sniff", true);
        anim.SetBool("sit", false);
    }

    void Aggression()
    {
        anim.SetFloat("Hor", horiz);
        anim.SetFloat("Vert", vertic);
        anim.SetBool("idle", false);
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        anim.SetBool("talk", false);
        anim.SetBool("aggressive", true);
        anim.SetBool("sit", false);
    }

    void Sit()
    {
        anim.SetFloat("Hor", horiz);
        anim.SetFloat("Vert", vertic);
        anim.SetBool("idle", false);
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        anim.SetBool("talk", false);
        anim.SetBool("aggressive", false);
        anim.SetBool("sit", true);
    }
}
