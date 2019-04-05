using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Zoom : MonoBehaviour
{

    void Update()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView > 15)
            {
                GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView --;
            }

            // GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 5;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView < 40)
            {
                GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView ++;
            }
            //GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = --;

        }
    }
}
