using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Disappearable : MonoBehaviour
{
    public GameRegion gameRegion;

    private Transform tr;
    private SpriteRenderer sprite;

    private void Start()
    {
        tr = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 pos = (Vector2) tr.position - gameRegion.Offset;
        float spriteDiameter = (sprite.size * transform.lossyScale).magnitude;
        
        if (Math.Max(Math.Abs(pos.x) - gameRegion.Size.x / 2, Math.Abs(pos.y) - gameRegion.Size.y / 2) > spriteDiameter)
        {
            Destroy(gameObject);
        }
    }
}
