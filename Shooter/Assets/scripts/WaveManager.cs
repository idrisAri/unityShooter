using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    private float timePassed;
    public Enemy enemyPrefab;
    public float spawnInterval;
    public float enemySpeed;
    public Response response;

    public Vector3 debugLogVector;

    public List<String> activeWaves;


    private void Start()
    {
        string jsonString = File.ReadAllText("Assets/configs/WaveInfo.json");
        response = JsonUtility.FromJson<Response>(jsonString);
        activeWaves = new List<string>();
        debugLogVector = new Vector3(0.06F, 4.5F, 11);
    }

    void FixedUpdate()
    {
        timePassed += Time.deltaTime;
        updateWaves();
    }


        private void updateWaves()
    {
        foreach (Wave wave in response.waveList)
        {
            if(!wave.hasCompleted)
            {
                if(wave.isActive)
                {
                    if ((wave.startTime + wave.duration) < timePassed)
                    {
                        wave.hasCompleted = true;
                        activeWaves.Remove(wave.waveName);
                    }
                    else
                    {
                        wave.Update();
                    }
                }
                else
                {
                    if (wave.startTime < timePassed)
                    {
                        wave.activate(transform);                       
                        activeWaves.Add(wave.waveName);
                    }
                }
            }
        }
    }


    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public float startTime;
        public float duration;
        public string spawnPosition;
        public float interval;
        public float count; 
        public string enemy;

        public bool isActive;
        public bool hasCompleted;

        private float timeRemaining;
        public Transform transform;
        public UnityEngine.Object enemyToSpawn;
        public Vector3 position;

        public void Update()
        {
            
            timeRemaining -= Time.deltaTime;
            if(timeRemaining <= 0)
            {
                spawnEnemies();
                timeRemaining = interval;
            }

        }


        public void activate(Transform transform)
        {
            isActive = true;
            this.transform = transform;
            enemyToSpawn = Resources.Load("prefabs/Enemies/" + enemy, typeof(GameObject));
            position = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Random.Range(0,Screen.width), Screen.height, 10));
        }

        private void spawnEnemies()
        {
            for (int i = 0; i < count; i++)
            {
                if (spawnPosition == "top")
                    position = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Random.Range(0, Screen.width), Screen.height, 10));
                else
                    position = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Random.Range(0, Screen.width), -Screen.height, 10));

                GameObject instance = Instantiate(enemyToSpawn, position, Quaternion.identity) as GameObject;
            }
        }
    }

    [System.Serializable]
    public class Response
    {
        public List<Wave> waveList;
    }


    void OnDrawGizmos()
    { 
        //debugLogVector = Camera.main.ScreenToWorldPoint(new Vector3(1F, Screen.height, 50));
        //Handles.Label(new Vector3(debugLogVector.x, debugLogVector.y - 0.5F, debugLogVector.z), (int)timePassed + "");
        //int i = 0;
        //foreach(string s in activeWaves)
        //{
        //    Handles.Label(new Vector3(debugLogVector.x, debugLogVector.y - 1F - (i * 0.5f), debugLogVector.z), s);
        //    i ++;
        //}
    }

}
