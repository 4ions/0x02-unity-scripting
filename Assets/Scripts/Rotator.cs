using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float yRotation;
    void Update()
    {
        yRotation += Time.deltaTime * 45;
        transform.rotation = Quaternion.Euler(0, yRotation, 90);
        
    }
}
