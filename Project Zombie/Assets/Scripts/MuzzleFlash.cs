using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public GameObject muzzleFlashPrefab; // Muzzle Flash efekti prefabı
    public Transform muzzleFlashSpawnPoint; // Muzzle Flash'in doğduğu nokta
    public float muzzleFlashDuration = 0.2f; // Muzzle Flash'in süresi (saniye)

    private void Start()
    {
        // Muzzle Flash efektini etkisiz hale getirin (başlangıçta görünmez)
        muzzleFlashPrefab.SetActive(false);
    }

    // Silah ateşlendiğinde bu fonksiyon çağrılır
    public void Atesle()
    {
        // Muzzle Flash efektini etkinleştirin
        muzzleFlashPrefab.SetActive(true);

        // Belirli bir süre sonra Muzzle Flash'i etkisizleştirin
        Invoke("KapatMuzzleFlash", muzzleFlashDuration);
    }

    private void KapatMuzzleFlash()
    {
        // Muzzle Flash efektini etkisiz hale getirin
        muzzleFlashPrefab.SetActive(false);
    }
}
