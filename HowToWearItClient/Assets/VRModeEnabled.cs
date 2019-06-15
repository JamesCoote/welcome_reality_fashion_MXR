using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRModeEnabled : MonoBehaviour
{
    public bool enableVR;

    // Start is called before the first frame update
    void Awake()
    {
        XRSettings.enabled = enableVR;
    }

    void Update()
    {
        //XRSettings.enabled = enableVR;
    }

}
