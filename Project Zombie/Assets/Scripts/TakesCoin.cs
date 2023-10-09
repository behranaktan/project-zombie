using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakesCoin : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Eğer altınla çarpışma gerçekleştiyse ve çarpışan diğer nesne "Oyuncu" ise altını al
        if (collision.gameObject.CompareTag("Player"))
        {
            // Altını yok et (veya devre dışı bırakabilirsiniz)
            Destroy(gameObject);
            
            // Oyuncunun puanını artırabilirsiniz
            PlayerController oyuncuKontrol = collision.gameObject.GetComponent<PlayerController>();
            if (oyuncuKontrol != null)
            {
                oyuncuKontrol.PuanArtir(1); // Örnek olarak puanı 1 artırabilirsiniz
            }
        }
    }
}
