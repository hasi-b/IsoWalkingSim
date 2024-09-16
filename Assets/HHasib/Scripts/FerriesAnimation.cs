using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FerriesAnimation : MonoBehaviour, IInteractable
{

   [SerializeField] CinemachineVirtualCamera ferriesAnimCam;



    public void NPCAction()
    {
        gameObject.tag = "Untagged";
        ferriesAnimCam.Priority = 13;
        StartCoroutine(Delay());
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(6f);

        gameObject.tag = "NPC";

        ferriesAnimCam.Priority = 8;
    }
}
