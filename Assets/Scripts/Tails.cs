using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Tails : MonoBehaviour
{
    public TMP_Text txt;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        txt.text = "Heads";
    }
}
