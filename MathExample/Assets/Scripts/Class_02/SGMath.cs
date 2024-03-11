using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SGMath : MonoBehaviour
{
    // �޸�
    // �Լ��� ���鶧�� ���и� �����Ͽ� ���ܸ� ���� ����

    // �ڷ���


    // ����

    public static float Magnitude(Vector3 a)
    {
        //return Mathf.Sqrt(a.magnitude);
        var px = Mathf.Pow(a.x, 2);
        var py = Mathf.Pow(a.y, 2);
        var pz = Mathf.Pow(a.z, 2);

        return Mathf.Sqrt(a.x + a.y + a.z);
    }

    // ���� ����

    public static Vector3 Normalize(Vector3 a)
    {
        //var normal = a.normalized;
        var magnitude = Magnitude(a);

        return new Vector3(a.x / magnitude, a.y / magnitude, a.z / magnitude);
    }

    // ������ ����

    public static Vector3 Add(Vector3 a, Vector3 b)
    {
        //1 + 2 = 3 
        //return a + b;
        return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    // ������ ����

    public static Vector3 Subtract(Vector3 a, Vector3 b)
    {
        //return a - b;
        return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    // ������ ��Į�� ��

    public static Vector3 Scale(Vector3 a, float scarlar)
    {
        //return a * scarlar;
        return new Vector3(a.x * scarlar, a.y * scarlar, a.z * scarlar);
    }

    // �� ������ ����

    public static float Dot(Vector3 a, Vector3 b)
    {
        // ������ ���� ���Ͷ�� �����ϰ�

        //return Vector3.Dot(a, b);
        var top = a.x * b.x + a.y * b.y + a.z * b.z;
        var px = Mathf.Pow(a.x, 2);
        var py = Mathf.Pow(a.y, 2);
        var pz = Mathf.Pow(a.z, 2);

        var qx = Mathf.Pow(b.x, 2);
        var qy = Mathf.Pow(b.y, 2);
        var qz = Mathf.Pow(b.z, 2);

        var bottom = Mathf.Sqrt(px + py + pz) * Mathf.Sqrt(qx + qy + qz);

        return Mathf.Acos(top / bottom);
    }

    public static float ThetaToRadian(float theta)
    {
        return Mathf.Acos(theta);
    }

    // ���� ��ȯ

    public static float RadianToDegree(float radian)
    {
        return 0;
    }

    // ��׸� ��ȯ

    public static float DegreeToRadian(float degree)
    {
        return 0;
    }

    // �� ������ ����

    public static Vector3 Cross(Vector3 a, Vector3 b)
    {
        return Vector3.zero;
    }


}
