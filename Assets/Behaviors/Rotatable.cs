using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatable : MonoBehaviour
{
    public float angularVelocity;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, angularVelocity));
    }
}
