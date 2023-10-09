using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bataklik : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Eğer oyuncu alanın içine girdiyse, yürüme hızını yavaşlat
            PlayerController oyuncuKontrol = other.GetComponent<PlayerController>();
            if (oyuncuKontrol != null)
            {
                oyuncuKontrol.Yavaslat();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Eğer oyuncu alanın dışına çıktıysa, yavaşlatmayı geri al
            PlayerController oyuncuKontrol = other.GetComponent<PlayerController>();
            if (oyuncuKontrol != null)
            {
                oyuncuKontrol.YavaslatmayiGeriAl();
            }
        }
    }
}
