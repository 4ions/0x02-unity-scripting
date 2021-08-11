using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    // Camera Shake

    public float shakeFrecuency;

    public bool _shaked = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_shaked == false)
        {
            transform.position = player.transform.position + offset;
        }
        else
        {
            CameraShaked();
        }

        
    }

    public void CameraShaked()
    {
        transform.position = player.transform.position + offset + Random.insideUnitSphere * shakeFrecuency;
        Invoke("StopShake", 0.1f);
        Debug.Log("SHAKE!!!!!!");
    }

    void StopShake()
    {
        _shaked = false;
    }

    
}
