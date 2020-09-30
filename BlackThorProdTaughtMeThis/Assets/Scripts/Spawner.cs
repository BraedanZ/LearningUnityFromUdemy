using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] hazards;

    public float minTimeBetweenSpawns;
    public float decrease;
    public float startTimeBetweenSpawns;
    private float timeBetweenSpawns;
    public float startRestTime;

    public GameObject player;

    // Update is called once per frame
    void Update() {
        if (startRestTime <= 0) {
            if (player != null) {
                if (timeBetweenSpawns <= 0) {
                    Transform randomSpawnPoint1 = spawnPoints[Random.Range(0, spawnPoints.Length)];
                    Transform randomSpawnPoint2 = spawnPoints[Random.Range(0, spawnPoints.Length)];
                    GameObject randomHazard1 = hazards[Random.Range(0, hazards.Length)];
                    GameObject randomHazard2 = hazards[Random.Range(0, hazards.Length)];
                    int doubleSpawn = Random.Range(0, 2);

                    Instantiate(randomHazard1, randomSpawnPoint1.position, Quaternion.identity);
                    if (randomSpawnPoint1 != randomSpawnPoint2 && doubleSpawn == 1) {
                        Instantiate(randomHazard2, randomSpawnPoint2.position, Quaternion.identity);
                    }
                
                    if (startTimeBetweenSpawns > minTimeBetweenSpawns) {
                    startTimeBetweenSpawns -= decrease;
                    }
                    timeBetweenSpawns = startTimeBetweenSpawns;
                } else {
                    timeBetweenSpawns -= Time.deltaTime;
                }
            }
        } else startRestTime -= Time.deltaTime;
    }
}
