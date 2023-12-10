using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycasat : MonoBehaviour
{
    public static float DistanceFromTarget;
    public float toTarget;
    
    

    private void Start()
    {
       
    }
    




    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            toTarget = hit.distance;
            DistanceFromTarget = toTarget;
        }
      
    }
}
