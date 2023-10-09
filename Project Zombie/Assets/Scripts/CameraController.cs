using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 2.0f;
    public float zoomSpeed = 2.0f;

    private Vector3 _offset;
    
    void Start()
    {
        _offset = transform.position - target.position; //kamera ve hedef obje arasundaki mesafeyi hesaplar
    }

    private void LateUpdate()
    {
        
        //Kamerayı hedefin etrafında döndürmek fare ile
        float horizontaInput = Input.GetAxis("Horizontal");
        transform.RotateAround(target.position,Vector3.up,horizontaInput*rotationSpeed);
        
        //kamera zoom yapması
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        Vector3 desiredPosition = transform.position - (_offset * zoomInput * zoomSpeed);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);
        
        
        //kameranın her zaman hedefi takip etmesi 
        
        transform.LookAt(target);
    }
}
