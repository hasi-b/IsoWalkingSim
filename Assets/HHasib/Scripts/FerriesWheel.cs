using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerriesWheel : MonoBehaviour
{
  
    public float rotationSpeed = 10f;

    List<GameObject> childList = new List<GameObject>();

    private void Awake()
    {
        foreach (Transform childTransform in gameObject.transform)
        {
            // Add the child game object to the list
            childList.Add(childTransform.gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);


        for (int i = 0; i < childList.Count; i++)
        {
            Vector3 rotation = new Vector3(childList[i].transform.rotation.x, childList[i].transform.rotation.y, gameObject.transform.rotation.z - childList[i].transform.rotation.z);
            childList[i].transform.rotation = Quaternion.Euler(rotation);
        }

    }


}
