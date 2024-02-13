using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tablo : MonoBehaviour
{
    Puzzle puzzle;
    Animator anim;
    void Start()
    {
        puzzle = FindObjectOfType<Puzzle>();    
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (puzzle.sag == true && puzzle.sol == true)
        {
            anim.enabled = true;
        }
    }
}
