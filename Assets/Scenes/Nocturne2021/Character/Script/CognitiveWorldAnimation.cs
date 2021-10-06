using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CognitiveWorldAnimation : MonoBehaviour
{

    [SerializeField] Animator cognitiveSwitchTransition;
    // Start is called before the first frame update
    public void PlayCognitiveAnimation()
    {
        cognitiveSwitchTransition.SetTrigger("StartAnimation");
    }

}
