using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform followObject;
    public float changeInY;

    // Update is called once per frame
    void FixedUpdate()
    {
        float prvPositionY = transform.position.y;
        transform.position = new Vector3(transform.position.x, followObject.position.y, transform.position.z);
        changeInY = transform.position.y - prvPositionY;
    }
}
