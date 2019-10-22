using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public float minimumY = -50F;
    public float maximumY = 50F;

    float rotationY = 0F;


    public void CameraYRotation()
    {
        rotationY += Input.GetAxis("Mouse Y");
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
    }

}

