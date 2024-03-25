using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonGenerator : MonoBehaviour
{
    public GameObject[] colliders;

    public void OnClear()
    {
        foreach( var item in colliders)
        {
            item.SetActive(false);
        }
    }

    public void OnColliderClick(int id)
    {
        OnClear();
        switch(id)
        {
            case 0:
                OnBoxCollider(id);
                break;
            case 1:
                OnCircleCollider(id);
                break;
            case 2:
                OnAABBCollider(id);
                break;
        }
    }

    public void OnBoxCollider(int id)
    {
        colliders[id].SetActive(true);
    }

    public void OnCircleCollider(int id)
    {
        colliders[id].SetActive(true);
    }

    public void OnAABBCollider(int id)
    {
        colliders[id].SetActive(true);
    }


}
