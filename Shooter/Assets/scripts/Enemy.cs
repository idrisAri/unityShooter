using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, GameObjectProperties
{
    public float hp;
    public float damage;
    public float speed;
    public bool shootBulletOnInterval;
    public float shootInterval;
    public GameObject bullet;   



    public float shootTimeRemaining;



    public GameObject player;
    public Rigidbody2D rigidBody;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player");

        shootTimeRemaining = shootInterval;
    }


    void Update()
    {
        if (shootBulletOnInterval)
        {
            shootTimeRemaining -= Time.deltaTime;
            if (shootTimeRemaining <= 0)
            {
                shootBullet();
                shootTimeRemaining = shootInterval;
            }
        }
        
    }

    private void shootBullet()
    {
        Instantiate(bullet, transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = (player.transform.position - transform.position).normalized * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("playerBullet"))
        {
            float damage = collision.gameObject.GetComponent<GameObjectProperties>().getDamage();
            deductHp(damage);
        }
    }

    public float getHp()
    {
        return hp;
    }

    public float getDamage()
    {
        return damage;
    }

    public float getSpeed()
    {
        return speed;
    }

    public void deductHp(float damage)
    {
        hp -= damage;
        if (hp <= 0)
            Destroy(gameObject);

    }
}
