using System.Collections;
using UnityEngine;

// Currently not in a working state since the transition from coroutines to fixed update calls

public class AnimationEventComponent : StoryEventComponent
{
    public Animator AnimatorController;
    public string AnimatorParameterName;
    public string StateName;
    bool animatorStartedPlaying = false;
    public bool IsLooping = false;
    public bool Interrupted = false;

    public void Init(Animator Controller, string stateName, string paramName, bool isLooping)
    {
        AnimatorController = Controller;
        StateName = stateName;
        AnimatorParameterName = paramName;
        IsLooping = isLooping;
    }


    public override void DoEventAction()
    {
        StartAnimation();
        Interrupted = false;

        //if (!IsLooping)
        //{
        //    yield return new WaitUntil(() => !AnimatorIsPlaying(StateName));
        //}
        //else
        //{
        //    yield return new WaitUntil(() => Interrupted);
        //}
    }


    public override void DoEventStoppedAction()
    {
        AnimatorController.SetBool(AnimatorParameterName, false);
        Interrupted = true;
    }


    // AnimatorIsPlaying methods used from https://answers.unity.com/questions/362629/how-can-i-check-if-an-animation-is-being-played-or.html 
    bool AnimatorIsPlaying()
    {
        return AnimatorController.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f;
    }


    bool AnimatorIsPlaying(string stateName)
    {
        bool isPlaying = AnimatorIsPlaying() && AnimatorController.GetCurrentAnimatorStateInfo(0).IsName(stateName);

        //Prevent returning false before animator has started playing
        if (!animatorStartedPlaying)
        {
            animatorStartedPlaying = isPlaying;
            return true;
        }

        if (!isPlaying)
        {
            DoEventStoppedAction();
        }

        return isPlaying;
    }


    void StartAnimation()
    {
        AnimatorController.SetBool(AnimatorParameterName, true);
    }
}