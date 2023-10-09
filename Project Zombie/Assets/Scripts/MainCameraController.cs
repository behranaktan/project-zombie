using System;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    public Transform target; //Kameranın taki edeceği obje
    public float rotationSpeed = 2.0f;//Kameranın Dönme hızı
    private float minYRotation = -80.0f; //kameranın minimum yatay dönme açısı
    private float maxYRotation = 80.0f;//kameranın max yatay dönme açısı

    private float currentXRotation = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//faareyi ekranın içinde kilitledi
    }

    private void LateUpdate()
    {
        //kamera yatay döndürme
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        target.Rotate(Vector3.up*mouseX);
        
        
        //kamerayı dikey döndürme
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
        currentXRotation -= mouseY;
        currentXRotation = Math.Clamp(currentXRotation, minYRotation, maxYRotation);
        transform.localEulerAngles = new Vector3(currentXRotation, transform.localEulerAngles.y,0);

    }
}
