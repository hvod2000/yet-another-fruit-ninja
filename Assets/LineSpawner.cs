using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LineSpawner : MonoBehaviour
{
    public float probability;
    [SerializeField] private float angle1;
    [SerializeField] private float angle2;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 boundary1;
    [SerializeField] private Vector2 boundary2;
    [SerializeField] private GameObject childPrefab;
    [SerializeField] private GameRegion gameRegion;


    public void Spawn()
    {
        float spawnAngle = Random.Range(angle1, angle2) * Mathf.Deg2Rad;
        Vector2 spawnPoint = boundary1 + Random.Range(0f, 1f) * (boundary2 - boundary1);
        Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0f, (float)Math.PI * 2));
        spawnPoint = gameRegion.Offset + spawnPoint * gameRegion.Size;
        GameObject child = Instantiate(childPrefab, spawnPoint, rotation);
        child.transform.parent = transform.parent;

        if (child.TryGetComponent<Fallable>(out var fallable))
        {
            fallable.gameRegion = gameRegion;
            fallable.velocity = new Vector2(Mathf.Cos(spawnAngle), Mathf.Sin(spawnAngle)) * speed;
        }

        if (child.TryGetComponent<Disappearable>(out var disappearable))
        {
            disappearable.gameRegion = gameRegion;
        }

        if (child.TryGetComponent<Rotatable>(out var rotatable))
        {
            rotatable.angularVelocity = Random.Range(-1.0f, 1.0f) * Mathf.PI * 2;
        }

        if (child.TryGetComponent<Scalable>(out var scalable))
        {
            scalable.scaleSpeed = Random.Range(1f, 1.25f);
        }
    }
}
