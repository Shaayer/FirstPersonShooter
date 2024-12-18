using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float pitch, yaw, roll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");
        yaw += horizontal;
        pitch -= vertical;
        Vector3 newRotation = new Vector3(pitch, yaw, roll);
        transform.localRotation = Quaternion.Euler(newRotation);
    }
}
