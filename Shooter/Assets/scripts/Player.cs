using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, GameObjectProperties
{
    public float hp;
    public float damage;
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void deductHp(float damage)
    {
        //Debug.Log("Hit By Bullet");
        //hp -= damage;
        //if (hp <= 0)
        //    Destroy(gameObject);
    }

    public float getDamage()
    {
        return damage;
    }

    public float getHp()
    {
        return hp;
    }

    public float getSpeed()
    {
        return speed;
    }


}
