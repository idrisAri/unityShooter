using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBullet : MonoBehaviour
{
    public float rotateSpeed;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(player.transform.position, new Vector3(0, 0, 1), rotateSpeed * Time.deltaTime);
    }
}
