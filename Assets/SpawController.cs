using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawController : MonoBehaviour
{
    [SerializeField] private List<LineSpawner> spawners;
    [SerializeField] private float frequency;

    private float passedSinceSpawn = 0f;
    private float probabilitySum;

    private void Start()
    {
        foreach (var spawner in spawners)
        {
            probabilitySum += spawner.probability;
        }
    }

    void Update()
    {
        passedSinceSpawn += Time.deltaTime;
        if (passedSinceSpawn >= frequency)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        float choosed = Random.Range(0f, probabilitySum);
        
        foreach (var spawner in spawners)
        {
            choosed -= spawner.probability;
            if (choosed <= 0)
            {
                spawner.Spawn();
            }
        }
        passedSinceSpawn = 0;
    }
}
