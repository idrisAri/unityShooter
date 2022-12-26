using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour, GameObjectProperties
{
    public float hp;
    public float damage;
    public float speed;

    GameObject player;
    private Rigidbody2D rigidBody;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = (player.transform.position - transform.position).normalized * speed;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, rigidBody.velocity);

    }

    void FixedUpdate()
    {
        
    }

    public float getHp()
    {
        return hp;
    }

    public void deductHp(float damage)
    {
        hp -= damage;
        if (hp <= 0)
            Destroy(gameObject);
    }

    public float getDamage()
    {
        return damage;
    }

    public float getSpeed()
    {
        return speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<GameObjectProperties>().deductHp(damage);
            Destroy(gameObject);
        }
    }
}
