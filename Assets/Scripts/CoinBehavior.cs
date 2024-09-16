using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public GameObject Coin;
    public Rigidbody rb;
    public TMP_Text textBox;


    void Start()
    {
        
        rb.maxAngularVelocity = 25;
    }

    public void CoinToss()
    {
        int jumpForce = Random.Range(100,200);
        rb.AddForce(0, jumpForce, 0);

        int torqX = Random.Range(120,1900);
        int torqZ = Random.Range(120,1900);
        rb.AddTorque(torqX, 0, torqZ);
        textBox.ClearMesh();
    }

    void Update()
    {
        
    }
}
