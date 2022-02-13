using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGeometry
{
    public static float Projection(Vector2 u, Vector2 v)
    {
        if (v.magnitude > 0)
        {
            return Vector2.Dot(u, v) / v.sqrMagnitude;
        }

        return 0;
    }

    public static float DistanceToLineSegment(Vector2 point, Vector2 lineStart, Vector2 lineEnd)
    {
        var t = Projection(point - lineStart, lineEnd - lineStart);
        t = Math.Max(0.0f, Math.Min(t, 1.0f));
        return (lineStart + t * (lineEnd - lineStart) - point).magnitude;
    }

    public static Vector2 ProjectPointOntoLine(Vector2 point, Vector2 lineStart, Vector2 lineDir)
    {
        return lineStart + Projection(point - lineStart, lineDir) * lineDir;
    }
}
