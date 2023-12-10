using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPuzzle : MonoBehaviour
{
    public bool isLeftObtained;
    public float theDistance;
    public GameObject actionKey;
    public GameObject bilgi;
    public AudioSource KeySound;
    public GameObject key;
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
                isLeftObtained = true;
                Destroy(key);
                bilgi.SetActive(true);
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
