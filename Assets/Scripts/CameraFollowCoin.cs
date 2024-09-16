using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCoin : MonoBehaviour
{
    public GameObject Coin;
    public Vector3 offset;

    void Start()
    {
        offset = transform.position - Coin.transform.position;
    }

    void LateUpdate()
    {
        transform.position = Coin.transform.position + offset;
    }
}
