using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ControlCamera : MonoBehaviour
{
    /*Summary: 
     * Allow for smooth rotation of the camera by 120 degrees 
     * by pressing inputs 1 and 2 (by default).*/


    Quaternion startRotation;
    Quaternion endRotation;
    float rotationProgress = -1;
    float savedRotation;

    void StartRotating(float yPosition)
    {

        //Starting and target rotations
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yPosition, transform.rotation.eulerAngles.z);
        rotationProgress = 0;
    }

    void Update()
    {
        if (rotationProgress < 1 && rotationProgress >= 0)
        {
            rotationProgress += Time.deltaTime * 4;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotationProgress);
        }

        if (Input.GetButtonDown("Rotate R"))
        {
            if(savedRotation == 360)
            {
                savedRotation = 0;
            }
            StartRotating(savedRotation+=120);
        }
        else if (Input.GetButtonDown("Rotate L"))
        {
            if (savedRotation == 360)
            {
                savedRotation = 0;
            }
            StartRotating(savedRotation -= 120);
        }
    }

    
}