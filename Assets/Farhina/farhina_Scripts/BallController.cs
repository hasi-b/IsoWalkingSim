using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour,Interactable
{
    public bool IsInteractable { get; set; }

    private void Start()
    {
        IsInteractable = true;
    }

    public void Interact()
    {
        // Do something when interacting with the ball
        Debug.Log("Interacting with ball");
    }
}
