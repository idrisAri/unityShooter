using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player.transform)
        {
            Vector3 point = Camera.main.WorldToViewportPoint(player.transform.position);
            if (point.y > 0.6 || point.y < 0.3)
            {
                Vector3 delta = player.transform.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                Vector3 destination = transform.position + delta;
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x, destination.y, transform.position.z), ref velocity, dampTime);
            }
        }

    }

}
