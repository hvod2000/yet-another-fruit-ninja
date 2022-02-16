using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallable : MonoBehaviour
{
    [SerializeField] private float gravity = 1.0f;
    public GameRegion gameRegion;
    public Vector2 velocity = Vector2.zero;

    private void Start()
    {
        if (!gameRegion)
        {
            gameRegion = GetComponentInParent<GameRegion>();
        }

        gravity *= gameRegion.Size.y;
    }

    void Update()
    {
        Vector2 pos = transform.position;
        var a = new Vector2(0, -gravity);
        var t = Time.deltaTime;
        pos += (velocity * t + a * t * t / 2);
        velocity.y -= gravity * Time.deltaTime;
        transform.position = pos;
    }
}
