using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawController : MonoBehaviour
{
    [SerializeField] private List<LineSpawner> spawners;
    [SerializeField] private float delayBetweenGroups = 4.0f;
    [SerializeField] private float delayBetweenBlocks = 0.1f;
    [SerializeField] private int minGroupSize = 2;
    [SerializeField] private int maxGroupSize = 5;

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
        if (passedSinceSpawn >= delayBetweenGroups)
        {
            Spawn(Random.Range(minGroupSize, maxGroupSize + 1));
        }
    }

    void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Invoke("Spawn", delayBetweenBlocks * i);
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
                break;
            }
        }
        passedSinceSpawn = 0;
    }
}
