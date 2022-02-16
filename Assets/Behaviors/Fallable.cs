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
        pos += (velocity * Time.deltaTime - new Vector2(0, gravity) / 2f * Time.deltaTime * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
        transform.position = pos;
    }
}
