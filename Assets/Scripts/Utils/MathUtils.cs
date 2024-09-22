using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathUtils
{
    public static Vector2 GetRandomPointOnCircle(float radius)
    {
        float angle = Random.Range(0f, 2.0f * Mathf.PI);

        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);

        return new Vector2(x, y);
    }
}
