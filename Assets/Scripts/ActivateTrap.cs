using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrap : MonoBehaviour
{
    public int state = 0;

    public float speed = 10f;

    [SerializeField]
    private Transform _pointA, _pointB;

    public bool changeMaterial = false;

    private Material mat;
    [SerializeField]
    private Material _newMaterial;
    private Material _oldMaterial;

    private void Start()
    {
        
        _oldMaterial = GetComponent<MeshRenderer>().material;
    }
    void Update()
    {
        if (state == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, speed * Time.deltaTime);
            if (changeMaterial == true)
            {
                GetComponent<MeshRenderer>().material = _newMaterial;
            }

        }
        else if (state == 2)
        {

            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, speed / 2 * Time.deltaTime);

        }
        
        Debug.Log(this.transform.position + " / " + _pointB.position);
        if (transform.position == _pointB.position)
        {

            state = 2;
        }
        else if (transform.position == _pointA.position)
        {

            state = 0;
            if (changeMaterial == true)
            {
                GetComponent<MeshRenderer>().material = _oldMaterial;
            }

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
    }

    
}
