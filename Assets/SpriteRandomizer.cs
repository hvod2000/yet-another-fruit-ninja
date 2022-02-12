using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomizer : MonoBehaviour
{
    [SerializeField] private SpriteList sprites;

    private void Start()
    {
        if (TryGetComponent<SpriteRenderer>(out var sprite))
        {
            sprite.sprite = sprites.GetRandomSprite();
        }
    }
}
