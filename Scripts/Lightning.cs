using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public Light isik; // Unity'de baðlamýþ olduðunuz ýþýk nesnesi
    public bool isLeftObtained;
    public float maxSarj = 100f; // Maksimum þarj deðeri
    public float sarjAzalmaHizi = 5f; // Iþýðýn açýkken azalma hýzý
    public float sarjArtisHizi = 10f; // Iþýðýn kapalýyken artýþ hýzý

    private float sarj; // Mevcut þarj miktarý
    private bool isikAcik = false; // Iþýk açýk mý kapalý mý?
    FlashLight flashLight;

    void Start()
    {
        sarj = maxSarj; // Baþlangýçta maksimum þarj ile baþla
    }

    void Update()
    {
        // F tuþuna basýldýðýnda ýþýðý aç veya kapat
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleIsik();
        }

        // Iþýk açýksa ve þarj varsa þarjý azalt
        if (isikAcik && sarj > 0)
        {
            sarj -= sarjAzalmaHizi * Time.deltaTime;
        }
        // Iþýk kapalýysa ve maksimum þarj deðerine ulaþýlmadýysa þarjý artýr
        else if (!isikAcik && sarj < maxSarj)
        {
            sarj += sarjArtisHizi * Time.deltaTime;
        }

        // Þarj sýnýrlarýný kontrol et
        sarj = Mathf.Clamp(sarj, 0f, maxSarj);

        // Iþýðý kontrol et ve þarjý bitmiþse kapat
        isik.enabled = isikAcik && sarj > 0;
    }

    void ToggleIsik()
    {
        isikAcik = !isikAcik;
    }
}
