using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Minimap : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    //public CinemachineVirtualCamera cineMachineMiniMapCamera;
    public Camera miniMapCamera;
    public RawImage miniMapImage;
    public GameObject miniMappointerImage;
 
    public Vector3 offset;
    public static Minimap _instance;

    public static object Instance { get; internal set; }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void UpMinimap()
    {
     
    }

    private void LateUpdate()
    {
        // Update the position of the mini map camera to follow the player
        miniMappointerImage.transform.position = new Vector3(player.position.x, player.position.y + 1, player.position.z);
       
        miniMapCamera.transform.position = new Vector3(player.position.x, miniMapCamera.transform.position.y, player.position.z);

        // Rotate the mini map camera to match the orientation of the player
        miniMapCamera.transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
        miniMappointerImage.transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);


    }
}
