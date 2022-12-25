using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBullet : MonoBehaviour, GameObjectProperties
{
    public float rotateSpeed;
    GameObject player;
    public float damage;
    public float hp;
 

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

    public static explicit operator HammerBullet(GameObject v)
    {
        throw new NotImplementedException();
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
        return rotateSpeed;
    }

    public void deductHp(float damage)
    {
        hp -= damage;
        if (hp <= 0 )
            Destroy(gameObject);

    }
}
