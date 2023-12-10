using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Opening : MonoBehaviour
{
    public GameObject player;
    public GameObject fadeScreen;
    public GameObject textBox, textBox2;

    void Start()
    {
        player.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        fadeScreen.SetActive(false);
        textBox.GetComponent<Text>().text = "Neler oluyor, Neredeyim ben";
        textBox2.GetComponent<Text>().text = "Flash [ F ] kullanýlmadýðýnda þarj olur";
        yield return new WaitForSeconds(1.5f);
        textBox.GetComponent<Text>().text = "";
        textBox2.GetComponent<Text>().text = "";
        player.GetComponent<FirstPersonController>().enabled = true;
    }
}
