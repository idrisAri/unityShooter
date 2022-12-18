using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float bulletInterval;
    public float timeRemaining;
    public float bulletSpeed = 1;


    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = bulletInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = bulletInterval;
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log(transform.position.x);
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.speed = bulletSpeed;

    }
}
