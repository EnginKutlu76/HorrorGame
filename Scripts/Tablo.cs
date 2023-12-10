using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablo : MonoBehaviour
{
    Puzzle puzzle;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        puzzle = FindObjectOfType<Puzzle>();    
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzle.sag == true && puzzle.sol == true)
        {
            anim.enabled = true;
        }
    }
}
