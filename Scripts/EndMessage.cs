using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class EndMessage : MonoBehaviour
{
    public GameObject mesaj;
    FirstPersonController fpc;
    // Start is called before the first frame update
    void Start()
    {
        fpc = FindObjectOfType<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mesaj.SetActive(true);
            fpc.m_RunSpeed = 0;
            fpc.m_WalkSpeed = 0;
            StartCoroutine(LoadNextSceneAfterDelay(10f));
        }

    }
    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(3);
    }
}
