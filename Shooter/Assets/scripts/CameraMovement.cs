using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform followObject;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, followObject.position.y, transform.position.z);
    }
}
