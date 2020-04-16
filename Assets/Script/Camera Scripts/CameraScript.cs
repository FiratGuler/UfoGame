using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static float setX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UfoScript.instance!=null)
        {
            if (UfoScript.instance.isCrash == true)
            {
                MoveTheCamera();
            }
        }
        
    }
    void MoveTheCamera()
    {
        Vector3 temp = transform.position;
        temp.x = UfoScript.instance.GetPositionX();
        transform.position = temp;
    }
}
