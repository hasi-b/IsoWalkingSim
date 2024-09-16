using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingGate : MonoBehaviour, IInteractable
{


    public void NPCAction()
    {

        if(gameObject.CompareTag("NPC"))
        {
            SceneManager.LoadScene(2);
        }

       
    }
}
