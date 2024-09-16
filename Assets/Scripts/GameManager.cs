using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject currentBall;
    public Vector3 ballSpawnPosition;
    

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ThrowBall();
        }
    }

    public void ThrowBall()
    {
        Instantiate(ball, ballSpawnPosition, Quaternion.identity);
    }
}
