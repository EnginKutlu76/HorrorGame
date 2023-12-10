using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastDoor : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject actionText;
    public GameObject door;
    public AudioSource doorSound;
    Animator anim;
    rustKey key;
    void Start()
    {
        key = FindObjectOfType<rustKey>();
        anim = GetComponent<Animator>();
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
            if (Input.GetKey(KeyCode.E) && key.isKey2Obtained == true)
            {
                actionText.SetActive(false);
                actionKey.SetActive(false);
                anim.enabled = true;               
                doorSound.Play();
            }
            else
            {
                actionText.SetActive(false);
                actionKey.SetActive(false);
            }
        }
    }
    void OnMouseExit()
    {
        actionText.SetActive(false);
        actionKey.SetActive(false);
    }
}
