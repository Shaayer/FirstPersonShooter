using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform target;
    public float playerDistance = 0;
    float pitch, yaw, roll;
    public float mouseSensitivity = 5;
    public float scrollSensitivity = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame - animations - bulk of the process
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        float vertical = Input.GetAxis("Mouse Y") * mouseSensitivity;
        yaw += horizontal;
        pitch -= vertical;
        Vector3 newRotation = new Vector3(pitch, yaw, roll);
        transform.localRotation = Quaternion.Euler(newRotation);
        playerDistance += Input.mouseScrollDelta.y * scrollSensitivity;
        if (playerDistance <= 0)
        {
            playerDistance = 0;
        }

    }

    //every 50th of a second - no drawing - ideally all physics calculations - collisions
    private void FixedUpdate()
    {
        
    }

    //once every draw - immediately before the draw - fast to calculate - immediate change - the stuff that needs to happen every draw
    private void LateUpdate()
    {
        transform.position = target.position - transform.forward * playerDistance;
    }
}
