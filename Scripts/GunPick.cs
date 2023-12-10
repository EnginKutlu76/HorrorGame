using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPick : MonoBehaviour
{
    public bool isKeyObtained;
    public float theDistance;
    public GameObject actionKey;
    public GameObject bilgi;
    public AudioSource KeySound;
    public GameObject gun;
    public GameObject gunKey;
    void Start()
    {

    }


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
                isKeyObtained = true;
                Destroy(gun);
                bilgi.SetActive(true);
                gunKey.SetActive(true);
                Destroy(bilgi, 1f);
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
