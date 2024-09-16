using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMechanics : MonoBehaviour
{


    public static SaveMechanics instance;







    private void Awake()
    {
        instance = this;
    }


    public void SavePlayerPosition(Vector3 playerPosition)
    {
        PlayerPrefs.SetFloat("playerPosX",playerPosition.x);
        PlayerPrefs.SetFloat("playerPosY", playerPosition.y);
        PlayerPrefs.SetFloat("playerPosZ", playerPosition.z);

    }

    public Vector3 GetPlayerPostion()
    {

        return new Vector3(PlayerPrefs.GetFloat("playerPosX"), PlayerPrefs.GetFloat("playerPosY"), PlayerPrefs.GetFloat("playerPosZ"));
    }

    public void SavePlayerState()
    {



    }
    
}
