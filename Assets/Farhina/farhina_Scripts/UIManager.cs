using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject boxcollider;
    private int currentPanelIndex = 0;


    public void OnCollisionEnter(Collision collision)
    {
        panels[0].gameObject.SetActive(true);
        Debug.Log("ddj");
    }


   

}
