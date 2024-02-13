using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject bilgi;
    public AudioSource KeySound;
    public GameObject ammoBox;
    void Update()
    {
        theDistance = PlayerRaycasat.DistanceFromTarget;
    }
    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            actionKey.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                bilgi.SetActive(true);
                Destroy(ammoBox);
                actionKey.SetActive(false);
                Gun.AmmoInPocket += 13;
                Destroy(bilgi, 1f);
            }
        }
        else
        {
            actionKey.SetActive(false);
        }
    }
    void OnMouseExit()
    {
        actionKey.SetActive(false);
    }
    void DeactivateBilgi()
    {
        bilgi.SetActive(false);
    }
}
