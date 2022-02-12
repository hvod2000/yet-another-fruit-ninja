using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "sprites", menuName = "Sprite List", order = 1)]
public class SpriteList : ScriptableObject
{
    public List<Sprite> sprites;

    public Sprite GetRandomSprite()
    {
        return sprites[Random.Range(0, sprites.Count)];
    }
}
