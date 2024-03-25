using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CircleDrawAndDetect : MonoBehaviour
{
    public Transform otherCircle;

    public float radius = 1f;
    public int segments = 360;
    public Vector2 offset;

    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = false;
        DrawCircle();
    }

    public void DrawCircle()
    {
        float angle = 0;

        for(int i = 0; i < segments; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
            angle += 360 / segments;
        }
    }

    public void CheckCollision(Transform other)
    {
        if(other == null)
        {
            return;
        }

        float ohterRadius = other.GetComponent<CircleDrawAndDetect>().radius;
        float distance = Vector2.Distance(this.transform.position, other.transform.position);

        if(distance < (radius + ohterRadius))
        {
            Debug.Log("Ãæµ¹");
        }
    }
    void FixedUpdate()
    {
        CheckCollision(otherCircle);
    }
}
