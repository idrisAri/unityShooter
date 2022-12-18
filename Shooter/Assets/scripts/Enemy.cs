using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody;
    public Vector2 direction;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //rigidBody.velocity = direction * speed;
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = (player.transform.position - transform.position).normalized * speed;
    }


    public void setData(float s, Vector2 dir)
    {
        speed = s;
        direction = new Vector2(dir.x, dir.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("playerBullet"))
        {
            //Debug.Log("got shot");
            Destroy(gameObject);
        }
    }
}
