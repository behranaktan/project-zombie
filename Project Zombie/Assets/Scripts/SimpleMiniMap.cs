using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class SimpleMiniMap : MonoBehaviour
{
    public Transform target; //Ana kameranın takip edileceği obje
    public float height = 10.0f;//minimap kameranın yükeskliği
    public float distance = 10.0f;//minimap kameranın ana kameradan uzaklığı

    private void LateUpdate()
    {
        if (target != null)
        {
            //minimap kameranın pozisyonunu güncelle
            Vector3 newPosition = target.position;
            newPosition.y = height;
            transform.position = newPosition;
            
            //minimap kamerayı ana kameraya bakacak şekilde döndür
            transform.rotation=Quaternion.Euler(90.0f,target.eulerAngles.y,0.0f);
        }
    }
}
