using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneLookAt : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAt = endPoint.transform.position - startPoint.transform.position;
        transform.forward = lookAt.normalized;
        transform.position = startPoint.transform.position + ((endPoint.transform.position - startPoint.transform.position) / 2);
        transform.localScale = new Vector3(1, 1, (Vector3.Distance(startPoint.transform.position, endPoint.transform.position) / 2));
    }
}
