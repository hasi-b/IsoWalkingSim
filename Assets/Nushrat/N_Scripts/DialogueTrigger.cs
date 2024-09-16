using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    private bool playerInRange;

    private void Awake()
    {

        visualCue.SetActive(false);

    }

    private void Update()
    {
       
    }

    //private void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.gameObject.tag == "Player")
    //    {
    //        visualCue.SetActive(true);
    //        DialogueManager.instance.EnterDialogueMode(inkJSON);
    //    }
        
    //}

    //private void OnTriggerExit(Collider collider)
    //{
    //    if (collider.gameObject.tag == "Player")
    //    {
    //        visualCue.SetActive(false);
    //    }

    //}

}
