using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalable : MonoBehaviour
{
    public float scaleSpeed = 0.5f;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.localScale *= Mathf.Pow(scaleSpeed, Time.deltaTime);
    }
}
