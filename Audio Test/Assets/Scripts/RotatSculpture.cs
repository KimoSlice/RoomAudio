using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatSculpture : MonoBehaviour
{
    public float rotationX = 100f;
    public float rotationY = 100f;
    public float rotationZ = 100f;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotationX, rotationY, rotationZ) *Time.deltaTime);
        
    }
}
