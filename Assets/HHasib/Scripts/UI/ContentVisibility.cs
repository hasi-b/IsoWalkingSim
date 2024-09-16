using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentVisibility : MonoBehaviour
{


    [SerializeField] PlayerInteraction playerInteraction;
    [SerializeField] GameObject interectUiImage;
    

    private void Update()
    {
        
        if (playerInteraction.InterectDetection() && !DialogueManager.instance.InDialogue)
        {
           
            Show(interectUiImage);
        }
        else
        {
            
            Hide(interectUiImage);
        }
        

    }
    private void Show(GameObject interectImage)
    {
        interectImage.SetActive(true);
    }
    
    private void Hide(GameObject interectImage)
    {

        interectImage.SetActive(false);

    }
}
