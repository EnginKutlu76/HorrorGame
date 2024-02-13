using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lightning : MonoBehaviour
{
    public Light isik;

    public float maxSarj = 100f; 
    public float sarjAzalmaHizi = 5f; 
    public float sarjArtisHizi = 10f;
    private float sarj; 

    private bool isikAcik = false; 
    public bool isLeftObtained;
    FlashLight flashLight;
    void Start()
    {
        sarj = maxSarj; 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleIsik();
        }
        if (isikAcik && sarj > 0)
        {
            sarj -= sarjAzalmaHizi * Time.deltaTime;
        }
        else if (!isikAcik && sarj < maxSarj)
        {
            sarj += sarjArtisHizi * Time.deltaTime;
        }
        sarj = Mathf.Clamp(sarj, 0f, maxSarj);
        isik.enabled = isikAcik && sarj > 0;
    }
    void ToggleIsik()
    {
        isikAcik = !isikAcik;
    }
}
