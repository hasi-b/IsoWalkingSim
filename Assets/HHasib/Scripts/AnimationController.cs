using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController instance;


    private void Awake()
    {
        instance = this;
    }

    public void PlayAnimation(Animator animator, string floatParameterName,float parameterValue)
    {
        animator.SetFloat(floatParameterName,parameterValue);
    }
}
