using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarControl : MonoBehaviour
{
    public Animator animator;
    public GameObject _avatar;

    public GameObject spineBase;
    public GameObject spineMid;
    public GameObject neck;
    public GameObject head;
    public GameObject shoulderLeft;
    public GameObject elbowLeft;
    public GameObject wristLeft;
    public GameObject handLeft;
    public GameObject shoulderRight;
    public GameObject elbowRight;
    public GameObject wristRight;
    public GameObject handRight;
    public GameObject hipLeft;
    public GameObject kneeLeft;
    public GameObject ankleLeft;
    public GameObject footLeft;
    public GameObject hipRight;
    public GameObject kneeRight;
    public GameObject ankleRight;
    public GameObject footRight;
    public GameObject spineShoulder;
    public GameObject handTipLeft;
    public GameObject thumbTipLeft;
    public GameObject handTipRight;
    public GameObject thumbTipRight;
    

    // Start is called before the first frame update
    void Start()
    {
        //_avatar.transform.position = new Vector3(_spineKinectPos[0], _spineKinectPos[1] + spineAdjustment, _spineKinectPos[2]);
    }

    void OnAnimatorIK(int layerIndex)
    {

        MapPositions();
        SetRotation();



    }

    // https://answers.unity.com/questions/1453641/how-to-control-a-rigged-body-with-kinect.html

    void MapPositions()
    {
        _avatar.transform.position = spineMid.transform.position;

        if (animator)
        {
            // check if player is active
            if (_avatar.activeInHierarchy)
            {
                if (wristRight.transform.position != Vector3.zero)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, wristRight.transform.position);

                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, wristRight.transform.rotation);// * Quaternion.AngleAxis(180, Vector3.up));
                }
                if (wristLeft.transform.position != Vector3.zero)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, wristLeft.transform.position);

                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, wristLeft.transform.rotation);// * Quaternion.AngleAxis(180, Vector3.up));
                }

                if (ankleRight.transform.position != Vector3.zero)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftFoot, ankleRight.transform.position);

                    animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
                    animator.SetIKRotation(AvatarIKGoal.LeftFoot, ankleRight.transform.rotation * Quaternion.AngleAxis(180, Vector3.up));
                }
                if (ankleLeft.transform.position != Vector3.zero)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
                    animator.SetIKPosition(AvatarIKGoal.RightFoot, ankleLeft.transform.position);

                    animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
                    animator.SetIKRotation(AvatarIKGoal.RightFoot, ankleLeft.transform.rotation * Quaternion.AngleAxis(180, Vector3.up));
                }

                if (elbowRight.transform.position != Vector3.zero)
                {
                    animator.SetIKHintPosition(AvatarIKHint.LeftElbow, elbowRight.transform.position);
                    animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 1);
                }

                if (elbowLeft.transform.position != Vector3.zero)
                {
                    animator.SetIKHintPosition(AvatarIKHint.RightElbow, elbowLeft.transform.position);
                    animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1);
                }

                if (kneeRight.transform.position != Vector3.zero)
                {
                    animator.SetIKHintPosition(AvatarIKHint.LeftKnee, kneeRight.transform.position);
                    animator.SetIKHintPositionWeight(AvatarIKHint.LeftKnee, 1);
                }

                if (kneeLeft.transform.position != Vector3.zero)
                {
                    animator.SetIKHintPosition(AvatarIKHint.RightKnee, kneeLeft.transform.position);
                    animator.SetIKHintPositionWeight(AvatarIKHint.RightKnee, 1);
                }
            }
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);
            }
        }
    }

    void SetRotation()
    {
        // calculate body angle depending on the position of shoulders
        if (shoulderLeft.transform.position != Vector3.zero && shoulderRight.transform.position != Vector3.zero)
        {
            float _leftShoulderX = shoulderLeft.transform.position[0];
            float _leftShoulderY = shoulderLeft.transform.position[1];
            float _leftShoulderZ = shoulderLeft.transform.position[2];
            float _rightShoulderX = shoulderRight.transform.position[0];
            float _rightShoulderY = shoulderRight.transform.position[1];
            float _rightShoulderZ = shoulderRight.transform.position[2];

            float _absoluteX = Mathf.Abs(_leftShoulderX) + Mathf.Abs(_rightShoulderX);
            float _absoluteZ = Mathf.Abs(_leftShoulderZ - _rightShoulderZ);

            float _division = _absoluteX / _absoluteZ;
            float _spineAngleRadians = Mathf.Atan(_division);
            float _spineAngle;

            if (_leftShoulderZ > _rightShoulderZ)
            {
                _spineAngle = 90 + (_spineAngleRadians * (180.0f / Mathf.PI));
            }
            else
            {
                _spineAngle = 270 - (_spineAngleRadians * (180.0f / Mathf.PI));
            }

            _avatar.transform.rotation = Quaternion.AngleAxis(-_spineAngle, Vector3.up);
        }
    }

}
