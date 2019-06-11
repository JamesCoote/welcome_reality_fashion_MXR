using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class BodyToPlayer : MonoBehaviour
{
    public static Body body;
    public JointType jointType;
    private const float scaleFactor = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (body != null && body.Joints.ContainsKey(jointType))
        {
            Windows.Kinect.Joint joint = body.Joints[jointType];
            transform.position = new Vector3(joint.Position.X * scaleFactor, joint.Position.Y * scaleFactor, joint.Position.Z * scaleFactor);
        }
    }
}
