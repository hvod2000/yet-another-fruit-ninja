using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GameRegion : MonoBehaviour
{
    [SerializeField] private Camera camera = null;
    public Vector2 Size => size;
    public Vector2 Offset => offset;

    private Vector2 size;
    private Vector2 offset = Vector2.zero;
    
    void Start()
    {
        float height = 2f * camera.orthographicSize;
        float width = height * camera.aspect;
        size = new Vector2(width, height);
        offset = camera.transform.position;
    }
}
