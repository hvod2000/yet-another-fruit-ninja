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
        if (!gameRegion)
        {
            gameRegion = GetComponentInParent<GameRegion>();
        } 
    }

    void Update()
    {
        Vector2 pos = (Vector2) tr.position - gameRegion.Offset;
        var spriteDiameter = (sprite.size * transform.lossyScale).magnitude;
        var xDistance = Math.Max(Math.Abs(pos.x) - gameRegion.Size.x, 0.0f);
        var yDistance = Math.Max(Math.Abs(pos.y) - gameRegion.Size.y, 0.0f);
        var distance = Mathf.Sqrt(xDistance * xDistance + yDistance * yDistance);

        if (distance >= spriteDiameter)
        {
            Destroy(gameObject);
        }
    }
}
