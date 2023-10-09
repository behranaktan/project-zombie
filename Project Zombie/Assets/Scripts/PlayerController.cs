using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float normalSpeed = 5.0f;
    public float slowSpeed = 3.0f;
    public float jumpForce = 5.0f;
    private Rigidbody _rb;
    private bool _isGrouned = true;
    private float _groundCheckDistance = 2.0f;
    public int puan = 0;
    public Text puanText;
    
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        puanText = GameObject.Find("PuanText").GetComponent<Text>();
        UpdatePuanText();
    }

    private void Update()
    {
        _isGrouned = Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance);

        float _horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 _moveDirection = (transform.forward * verticalInput + transform.right * _horizontalInput).normalized;
        _rb.velocity = new Vector3(_moveDirection.x * speed, _rb.velocity.y, _moveDirection.z * speed);

        if (_isGrouned&& Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(Vector3.up* jumpForce,ForceMode.Impulse);
        }
    }
    

    public void PuanArtir(int artisMiktari)
    {
        puan += artisMiktari;
        UpdatePuanText();

    }

    void UpdatePuanText()
    {
        puanText.text = "Coin: " + puan.ToString();
    }

    public void Yavaslat()
    {
        speed = slowSpeed;
    }

    public void YavaslatmayiGeriAl()
    {
        speed = normalSpeed;
    }
    
}
