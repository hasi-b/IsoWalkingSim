using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDialogueNPC : MonoBehaviour, IInteractable
{

    AudioSource NpcAudio;
    [SerializeField]AudioClip audioClip;
    private void Awake()
    {
        NpcAudio = GetComponent<AudioSource>();
        
    }
    public void NPCAction()
    {
        gameObject.tag ="Finish";

        NpcAudio.PlayOneShot(audioClip);
        StartCoroutine(TagChange());
    }




    IEnumerator TagChange()
    {
        while (NpcAudio.isPlaying)
        {
            yield return null;
        }

        gameObject.tag = "NPC";


    }
}
