using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public   interface Interactable
{
 

   // This method is called when the player interacts with the object
    void Interact();

    // This property indicates whether the object is currently interactable
    bool IsInteractable { get; }
}

