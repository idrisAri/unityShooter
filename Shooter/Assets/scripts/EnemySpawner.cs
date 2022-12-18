using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    Transform[] spawnPoints;
    public float spawnInterval;
    private float timeRemaining;
    public float enemySpeed;

    void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
        Debug.Log("Total SpawnPoints : " + spawnPoints.Length);
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
            timeRemaining = spawnInterval;
            SpawnEnemy();
        }
    }


    public void SpawnEnemy()
    {
        for(int i=0; i<spawnPoints.Length; i++)
        {
            if (spawnPoints[i].gameObject.tag == "spawnpoint")
            {
                Enemy enemy = Instantiate(enemyPrefab, spawnPoints[i].position, spawnPoints[i].rotation);
                enemy.setData(enemySpeed, new Vector2(0,-2));
            }
        }
    }









}
