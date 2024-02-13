using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityRoomMessage : MonoBehaviour
{
    public GameObject mesaj;
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
