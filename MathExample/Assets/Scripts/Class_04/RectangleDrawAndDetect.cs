using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleDrawAndDetect : MonoBehaviour
{
    public Rect rectangle = new Rect(100, 100, 200, 200);

    public void OnGUI()
    {
        GUI.Box(rectangle, "�簢��");
        if(Event.current.type == EventType.MouseDown)
        {
            if(rectangle.Contains(Event.current.mousePosition))
            {
                Debug.Log("Click");
            }
        }
    }
}
