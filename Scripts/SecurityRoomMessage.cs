using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityRoomMessage : MonoBehaviour
{
    public GameObject mesaj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mesaj.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mesaj.SetActive(false);
        }
    }
}
