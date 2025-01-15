using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public Camera cam;
    public LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
            bool didHit = Physics.Raycast(mouseRay, out RaycastHit hit);
            if (didHit)
            {
                //line.SetPosition(0, mouseRay.origin);
                line.SetPosition(0, hit.point + hit.normal);
                line.SetPosition(1, hit.point);

            }
        }
        
    }
}
