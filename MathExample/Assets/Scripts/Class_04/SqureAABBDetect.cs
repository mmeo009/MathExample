using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SqureAABBDetect : MonoBehaviour
{
    public Transform squar1;
    public Transform squar2;

    public LineRenderer lineRenderer1;
    public LineRenderer lineRenderer2;

    public float size = 1.0f;

    private void Start()
    {
        lineRenderer1 = squar1.gameObject.AddComponent<LineRenderer>();
        lineRenderer2 = squar2.gameObject.AddComponent<LineRenderer>();
        SetupSqure(lineRenderer1, squar1.position, new Vector3(0.1f, 0, 0));
        SetupSqure(lineRenderer2, squar2.position, new Vector3(0, 0, 0));

    }

    public void SetupSqure(LineRenderer lineRenderer, Vector3 position, Vector3 offset)
    {
        lineRenderer.positionCount = 5;
        lineRenderer.useWorldSpace = true;
        lineRenderer.loop = true;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        float halfSize = size / 2;
        Vector3[] points = new Vector3[]
        {
            new Vector3(position.x - halfSize + offset.x,position.y + halfSize + offset.y, position.z + offset.z),
            new Vector3(position.x + halfSize + offset.x,position.y + halfSize + offset.y, position.z + offset.z),
            new Vector3(position.x + halfSize + offset.x,position.y - halfSize + offset.y, position.z + offset.z),
            new Vector3(position.x - halfSize + offset.x,position.y - halfSize + offset.y, position.z + offset.z),
            new Vector3(position.x - halfSize + offset.x,position.y + halfSize + offset.y, position.z + offset.z),
        };

        lineRenderer.SetPositions(points);
    }
    public void Update()
    {
        if(IsCollision(squar1, squar2, size))
        {
            Debug.Log("Ãæµ¹!");
        }
    }
    public bool IsCollision(Transform sq1, Transform sq2, float squareSize)
    {
        float halfSize = size / 2;
        bool xCollier = Mathf.Abs(sq1.position.x - sq2.position.x) < squareSize;
        bool yCollier = Mathf.Abs(sq1.position.y - sq2.position.y) < squareSize;
        return xCollier && yCollier;
    }
}
