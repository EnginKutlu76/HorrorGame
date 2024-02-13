using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SciFiGate : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject actionText;
    public GameObject door;
    public AudioSource doorSound;
    BoxCollider bxCol;
    KeyManager key;
    void Start()
    {
        key = FindObjectOfType<KeyManager>();
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
            if (Input.GetKey(KeyCode.E) && key.isKeyObtained == true)
            {
                actionText.SetActive(false);
                actionKey.SetActive(false);
                bxCol.enabled = false;
                door.GetComponent<Animation>().Play("GateOpen");
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
