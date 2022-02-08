using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallable : MonoBehaviour
{
    [SerializeField] private float gravity = 1.0f;
    public GameRegion gameRegion;
    public Vector2 velocity = Vector2.zero;
    
    private Transform tr;
    
    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        Vector2 pos = tr.position;
        pos += (velocity * Time.deltaTime - new Vector2(0, gravity) / 2f * Time.deltaTime * Time.deltaTime) * gameRegion.Size;
        velocity.y -= gravity * Time.deltaTime;
        tr.position = pos;
    }
}
