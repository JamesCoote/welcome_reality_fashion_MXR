using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneLookAt : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;
    public CapsuleCollider capsuleCollider;
    public Vector3 offset;

    public GameObject left;
    public GameObject right;

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAt = endPoint.transform.position - startPoint.transform.position;
        transform.forward = lookAt.normalized;
        if (left != null && right != null)
        {
            Vector3 rightLookAt = right.transform.position - left.transform.position;
            transform.right = rightLookAt.normalized;
        }

        transform.position = startPoint.transform.position + ((endPoint.transform.position - startPoint.transform.position) / 2) + offset;
        transform.localScale = new Vector3(1, 1, (Vector3.Distance(startPoint.transform.position, endPoint.transform.position) / 2));

        if (capsuleCollider != null)
        {
            capsuleCollider.height = transform.localScale.z;
        }
    }
}
