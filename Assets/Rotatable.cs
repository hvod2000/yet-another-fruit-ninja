using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatable : MonoBehaviour
{
    public float angularVelocity;

    private Transform tr;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        tr.Rotate(new Vector3(0, 0, angularVelocity));
    }
}
