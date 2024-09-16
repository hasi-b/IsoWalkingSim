using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    [SerializeField] public Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            playerAnimator.SetBool("ThrowBall", true);
            StartCoroutine(SetThrowAnimationFalse());
        }*/
    }

    public void throwBall()
    {
        playerAnimator.SetBool("ThrowBall", true);
        StartCoroutine(SetThrowAnimationFalse());
    }

    IEnumerator SetThrowAnimationFalse()
    {
        playerAnimator.SetBool("ThrowBall", true);
        yield return new WaitForSeconds(1f);
        playerAnimator.SetBool("ThrowBall", false);
    }

}
