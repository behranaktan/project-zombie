using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDonusumu : MonoBehaviour
{
    public Text npcMetin;
    public GameObject birinciNPC;
    public GameObject ikinciNPC;
    public Transform transfer;
    private bool donusumYapilabilir = false;



    private void Start()
    {
        npcMetin.text = "";
    }

    private void Update()
    {
        // "E" tuşuna basıldığında ve dönüşüm yapılabilir durumdaysa
        if (Input.GetKeyDown(KeyCode.E) && donusumYapilabilir)
        {
            DonusturNPC(); // NPC dönüşümünü gerçekleştir
        }
    }

    // Oyuncu Collider'ı NPC ile temas ettiğinde bu tetiklenir
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            donusumYapilabilir = true; // Dönüşüm yapılabilir durumunu etkinleştir
        }
    }

    // Oyuncu Collider'ı NPC ile temasını kestiğinde bu tetiklenir
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            donusumYapilabilir = false; // Dönüşüm yapılabilir durumunu devre dışı bırak
        }
    }

    // NPC dönüşümünü gerçekleştiren fonksiyon
    private void DonusturNPC()
    {
        if (ikinciNPC != null)
        {

            npcMetin.text = "Köylü: Bizde Yiyecek Birşeyler Bekliyorduk.";
            birinciNPC.SetActive(false);
            ikinciNPC.SetActive(true);
            ikinciNPC.transform.position = transfer.position;
            Destroy(npcMetin,2f);


        }
    }
}
