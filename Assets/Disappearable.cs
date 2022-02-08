using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Disappearable : MonoBehaviour
{
    public GameRegion gameRegion;

    private Transform tr;
    private float spriteRadius;

    private void Start()
    {
        tr = GetComponent<Transform>();
        if (TryGetComponent<SpriteRenderer>(out var sprite ))
        {
            spriteRadius = sprite.size.magnitude;
        }
    }

    void Update()
    {
        Vector2 pos = (Vector2) tr.position - gameRegion.Offset;
        
        if (Math.Max(Math.Abs(pos.x) - gameRegion.Size.x / 2, Math.Abs(pos.y) - gameRegion.Size.y / 2) > spriteRadius)
        {
            Destroy(gameObject);
        }
    }
}
