using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Slicesable : MonoBehaviour
{
    [SerializeField] private Slicer slicer;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private GameObject slicePrefab;
    [SerializeField] private float maxOfsset = 0.33f;

    private void Start()
    {
        if (!slicer)
        {
            slicer = GetComponentInParent<Slicer>();
        }

        if (!sprite)
        {
            sprite = GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        if (!slicer)
        {
            return;
        }


        if (slicer.isCutting)
        {
            Vector2 pos = transform.position;
            Vector2 tip2 = slicer.CurrentTipPosition;
            Vector2 tip1 = slicer.CurrentTipPosition - slicer.Direction;
            var dist = SimpleGeometry.DistanceToLineSegment(pos, tip1, tip2);
            var radius = (transform.localScale * sprite.size).y / 2;

            if (dist < radius)
            {
                Vector2 cut = SimpleGeometry.ProjectPointOntoLine(pos, tip1, tip2 - tip1);
                Slice(cut - pos, slicer.Direction.normalized);
            }
        }
    }

    public void Slice(Vector2 cutOffset, Vector2 direction)
    {
        var radius = (transform.localScale * sprite.size).y / 2;

        cutOffset *= Mathf.Min(1, maxOfsset * radius / cutOffset.magnitude);

        Vector2 normal = Vector3.Cross(direction, new Vector3(0, 0, 1)) * radius;

        var offset = SimpleGeometry.Projection(cutOffset, normal);
        var (left, right) = SliceSprite(sprite.sprite, offset);

        SpawnSlice(left, (cutOffset - normal) / 2 , direction, +Mathf.PI);
        SpawnSlice(right, (normal + cutOffset) / 2, direction, -Mathf.PI);
        Destroy(this.gameObject);
    }

    void SpawnSlice(Sprite sprite, Vector2 offset, Vector2 direction, float angularVelocity)
    {
        float rotationAngle = Mathf.Atan2(direction.y, direction.x) + Mathf.PI;
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * rotationAngle);
        var slice = Instantiate(slicePrefab, transform.position, rotation, transform.parent);
        slice.transform.position += (Vector3)offset;
        slice.transform.localScale = transform.localScale;

        if (slice.TryGetComponent<SpriteRenderer>(out var sliceSprite))
        {
            sliceSprite.sprite = sprite;
        }

        if (slice.TryGetComponent<Fallable>(out var sliceFallable))
        {
            if (TryGetComponent<Fallable>(out var fallable))
            {
                sliceFallable.velocity = fallable.velocity + offset;
            }
        }

        if (slice.TryGetComponent<Rotatable>(out var rotatable))
        {
            rotatable.angularVelocity = angularVelocity;
        }
    }

    (Sprite, Sprite) SliceSprite(Sprite sprite, float offset)
    {
        Vector2 size = new Vector2(sprite.texture.width, sprite.texture.height);
        offset *= size.y / 2;
        Rect leftRect = new Rect(0, 0, size.x, size.y / 2 + offset);
        Sprite left = Sprite.Create(sprite.texture, leftRect, new Vector2(0.5f, 0.5f));
        Rect rightRect = new Rect(0,  size.y / 2 + offset, size.x, size.y / 2 - offset);
        Sprite right = Sprite.Create(sprite.texture, rightRect, new Vector2(0.5f, 0.5f));
        return (left, right);
    }
}
