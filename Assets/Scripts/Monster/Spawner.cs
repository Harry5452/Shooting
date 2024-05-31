using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    float timer;

    void Awake()
    {
        List<Transform> spawnPointList = new List<Transform>();
        foreach (Transform child in transform)
        {
            if (child != transform)
                spawnPointList.Add(child);
        }
        spawnPoints = spawnPointList.ToArray();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.2f)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points found!");
            return;
        }
        Transform selectedSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        
        GameObject enemy = GameManager.instance.Pool.Get(Random.Range(0, GameManager.instance.Pool.prefabs.Length));
        if (enemy != null)
        {
            enemy.transform.position = selectedSpawnPoint.position;
        }
        else
        {
            Debug.LogError("Failed to spawn enemy!");
        }
    }
}
