using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public Light isik; // Unity'de ba�lam�� oldu�unuz ���k nesnesi
    public bool isLeftObtained;
    public float maxSarj = 100f; // Maksimum �arj de�eri
    public float sarjAzalmaHizi = 5f; // I����n a��kken azalma h�z�
    public float sarjArtisHizi = 10f; // I����n kapal�yken art�� h�z�

    private float sarj; // Mevcut �arj miktar�
    private bool isikAcik = false; // I��k a��k m� kapal� m�?
    FlashLight flashLight;

    void Start()
    {
        sarj = maxSarj; // Ba�lang��ta maksimum �arj ile ba�la
    }

    void Update()
    {
        // F tu�una bas�ld���nda ����� a� veya kapat
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleIsik();
        }

        // I��k a��ksa ve �arj varsa �arj� azalt
        if (isikAcik && sarj > 0)
        {
            sarj -= sarjAzalmaHizi * Time.deltaTime;
        }
        // I��k kapal�ysa ve maksimum �arj de�erine ula��lmad�ysa �arj� art�r
        else if (!isikAcik && sarj < maxSarj)
        {
            sarj += sarjArtisHizi * Time.deltaTime;
        }

        // �arj s�n�rlar�n� kontrol et
        sarj = Mathf.Clamp(sarj, 0f, maxSarj);

        // I���� kontrol et ve �arj� bitmi�se kapat
        isik.enabled = isikAcik && sarj > 0;
    }

    void ToggleIsik()
    {
        isikAcik = !isikAcik;
    }
}
