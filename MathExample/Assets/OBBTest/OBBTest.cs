using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBBTest : MonoBehaviour
{
    public Transform objectA;
    public Transform objectB;

    void Update()
    {
        OBB2D obbA = new OBB2D(objectA.position, objectA.localScale / 2, objectA.rotation.eulerAngles.z);
        OBB2D obbB = new OBB2D(objectB.position, objectB.localScale / 2, objectB.rotation.eulerAngles.z);

        if (obbA.IsColliding(obbB))
        {
            Debug.Log("Ãæµ¹ Áß!");
        }
    }

    void OnDrawGizmos()
    {
        if (objectA != null) DrawOBB(objectA, Color.red);
        if (objectB != null) DrawOBB(objectB, Color.blue);
    }

    void DrawOBB(Transform obj, Color color)
    {
        Gizmos.color = color;

        Vector2 center = obj.position;
        Vector2 halfExtents = obj.localScale / 2;
        float rotation = obj.rotation.eulerAngles.z * Mathf.Deg2Rad;

        Vector2[] vertices = new Vector2[4];
        vertices[0] = center + RotateVector(new Vector2(-halfExtents.x, -halfExtents.y), rotation);
        vertices[1] = center + RotateVector(new Vector2(halfExtents.x, -halfExtents.y), rotation);
        vertices[2] = center + RotateVector(new Vector2(halfExtents.x, halfExtents.y), rotation);
        vertices[3] = center + RotateVector(new Vector2(-halfExtents.x, halfExtents.y), rotation);

        Gizmos.DrawLine(vertices[0], vertices[1]);
        Gizmos.DrawLine(vertices[1], vertices[2]);
        Gizmos.DrawLine(vertices[2], vertices[3]);
        Gizmos.DrawLine(vertices[3], vertices[0]);
    }

    Vector2 RotateVector(Vector2 vector, float rad)
    {
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);
        return new Vector2(cos * vector.x - sin * vector.y, sin * vector.x + cos * vector.y);
    }
}

public class OBB2D
{
    public Vector2 Center;
    public Vector2[] Axes = new Vector2[2];
    public Vector2 HalfExtents;

    public OBB2D(Vector2 center, Vector2 halfExtents, float rotation)
    {
        Center = center;
        HalfExtents = halfExtents;
        float rad = rotation * Mathf.Deg2Rad;
        Axes[0] = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        Axes[1] = new Vector2(-Mathf.Sin(rad), Mathf.Cos(rad));
    }

    public bool IsColliding(OBB2D other)
    {
        return OBBCollision(this, other);
    }

    private bool OBBCollision(OBB2D a, OBB2D b)
    {
        for (int i = 0; i < 2; i++)
        {
            if (!OverlapOnAxis(a, b, a.Axes[i])) return false;
            if (!OverlapOnAxis(a, b, b.Axes[i])) return false;
        }

        return true;
    }

    private bool OverlapOnAxis(OBB2D a, OBB2D b, Vector2 axis)
    {
        float aMin, aMax, bMin, bMax;

        ProjectionOBB(axis, a, out aMin, out aMax);
        ProjectionOBB(axis, b, out bMin, out bMax);

        return (aMin <= bMax) && (bMin <= aMax);
    }

    private void ProjectionOBB(Vector2 axis, OBB2D obb, out float min, out float max)
    {
        float dotProduct = Vector2.Dot(obb.Center, axis);
        float radius =
            Mathf.Abs(Vector2.Dot(obb.Axes[0], axis) * obb.HalfExtents.x) +
            Mathf.Abs(Vector2.Dot(obb.Axes[1], axis) * obb.HalfExtents.y);

        min = dotProduct - radius;
        max = dotProduct + radius;
    }
}