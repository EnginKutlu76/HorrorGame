using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject actionText;
    public GameObject door;
    public AudioSource doorSound;
    BoxCollider bxCol;
    void Start()
    {
        bxCol = GetComponent<BoxCollider>();
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
            actionText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                actionText.SetActive(false);
                actionKey.SetActive(false);
                bxCol.enabled = false;
                door.GetComponent<Animation>().Play("Door");
                doorSound.Play();
            }
        }
        else
        {
            actionText.SetActive(false);
            actionKey.SetActive(false);
        }
    }
    void OnMouseExit()
    {
        actionText.SetActive(false);
        actionKey.SetActive(false); 
    }
}
