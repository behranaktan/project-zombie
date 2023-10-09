using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed = 10.0f;
    public float lifetime = 2.0f;

    private void Start()
    {
        //mermiyi ileri doğru hareket ettirir
        Rigidbody _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * speed;
        
        //belirlenen zaman sonra mermiyi yok et
        Destroy(gameObject,speed);
    }

}
