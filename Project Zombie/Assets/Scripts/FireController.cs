using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletForce = 10.0f;
    public MuzzleFlash muzzleFlash;
    public AudioSource gunSound;


    public void Update()
    {
        //farenin sol tuşuna basıldığında ates et
        if (Input.GetButtonDown("Fire1"))
        {
            FireBullet();

        }
    }

    private void FireBullet()
    {
        //mermi prefabına yeni bir mermi oluşturur
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
        
        //mermiye force uygular
        if (bulletRigidbody != null)
        {
            bulletRigidbody.AddForce(newBullet.transform.forward * bulletForce, ForceMode.Impulse);
        }
        muzzleFlash.Atesle();
        gunSound.Play();
    }

}
