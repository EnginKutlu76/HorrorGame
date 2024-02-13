using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public bool flashTaken;
    public float theDistance;
    public GameObject actionKey;
    public GameObject GetFlashText;
    public AudioSource KeySound;
    public GameObject flashLight;
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
                flashTaken = true;
                Destroy(flashLight);
                GetFlashText.SetActive(true);
                Destroy(GetFlashText, 1f);
                actionKey.SetActive(false);
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
}
