using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour
{
    public GameObject target;
    public Vector3 rotationBase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position;


        transform.rotation = target.transform.rotation * Quaternion.Euler(rotationBase);
    }
}
