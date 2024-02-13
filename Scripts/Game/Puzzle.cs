using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Puzzle : MonoBehaviour
{
    public GameObject right, left;
    RightPuzzle rightPuzzle;
    Lightning leftPuzzle;
    public bool sag = false;
    public bool sol = false;
    private void Start()
    {
        rightPuzzle = FindObjectOfType<RightPuzzle>();
        leftPuzzle = FindObjectOfType<Lightning>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && rightPuzzle.isRightObtained)
        {
            right.SetActive(true);
            sag = true;
        }
        if (other.CompareTag("Player") && leftPuzzle.isLeftObtained)
        {
            left.SetActive(true);
            sol = true;
        }
    }
}
