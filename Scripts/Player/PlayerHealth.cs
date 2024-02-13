using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public Image can;
    public float maxHealth = 100f;
    public float currentHealth;
    public GameObject medicine;
    public static PlayerHealth PH;
    public bool isDead;
    public GameObject damagePanel, deathPanel;

    [Header("Damage Screen")]
    public Color damageColor;
    public Image damageImage;
    bool isTakingDamage = false;
    FirstPersonController fpc;

    public float coloSpeed = 5f;
    private void Awake()
    {
        PH = this;
        fpc = FindObjectOfType<FirstPersonController>();
    }
    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        if (isTakingDamage)
        {
            damageImage.color = damageColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, coloSpeed * Time.deltaTime );
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        isTakingDamage = false;
    }
    public void DamagePlayer(float damage)
    {
        if (currentHealth > 0)
        {
            if (damage >= currentHealth)
            {
                    isTakingDamage = true;
                    Dead();   
            }
            else
            {
                isTakingDamage = true;
                currentHealth -= damage;
                can.fillAmount -= damage / 100;
            }   
        }
    }
    void Dead()
    {
        fpc.m_RunSpeed = 0;
        fpc.m_WalkSpeed = 0;
        deathPanel.SetActive(true);
        isDead = true;
        Debug.Log("Öldün");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Health"))
        {
            can.fillAmount += 0.25f;
            currentHealth += 25;
            Destroy(medicine);
        }
    }
}
