using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    Zombie zombie;
    public GameObject cross;
    void Start()
    {
        zombie = GetComponent<Zombie>();
    }
    private void Update()
    {
        if (enemyHealth <= 0)
        {
            enemyHealth = 0;
        }
    }
    public void ReduceHealt(float reduceHealth)
    {
        enemyHealth -= reduceHealth;

        if (!zombie.isDead)
        {
        zombie.Hit();

        }
        if (enemyHealth <= 0)
        {
            zombie.DeadAnim();
            Dead();
        }
    }
    public void Dead()
    {
        Destroy(gameObject, 10f);
    }
}
