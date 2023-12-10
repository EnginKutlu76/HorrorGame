using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    Transform target;
    public bool isDead = false;
    public float turnSpeed;

    public bool canAtak;
    [SerializeField]
    public float atakTimer = 2f;

    public float damage = 25f;
    private void Start()
    {
        canAtak = true;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance < 10 && distance > 2 && !isDead )
        {
            ChasePlayer();
        }
        else if (distance <= 2 && canAtak && !PlayerHealth.PH.isDead)
        {
            Atak();
        }
        else if (distance > 10)
        {
            StopChase();
        }
    }
    void StopChase()
    {
        agent.updatePosition = false;
        anim.SetBool("isRunning", false);
        anim.SetBool("Atak", false);
    }

    void ChasePlayer()
    {
        agent.updateRotation = true;
        agent.updatePosition = true;
        agent.SetDestination(target.position);
        anim.SetBool("isRunning", true);
        anim.SetBool("Atak", false);
    }

    public void DeadAnim()
    {
        agent.updatePosition = false;
        agent.updateRotation = false;
        isDead = true;
        anim.SetTrigger("Death");
    }
    public void Hit()
    {
        agent.updateRotation = false;
        anim.SetTrigger("hit");
        StartCoroutine(Nav());
    }
    void Atak()
    {
        agent.updateRotation = false;
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        agent.updatePosition = false;
        anim.SetBool("isRunning", false);
        anim.SetBool("Atak", true);

        StartCoroutine(AtakTimer());
    }
    IEnumerator Nav()
    {
        yield return new WaitForSeconds(1.5f);
        agent.enabled = true;
    }
    IEnumerator AtakTimer()
    {
        canAtak = false;
        yield return new WaitForSeconds(0.5f);
        PlayerHealth.PH.DamagePlayer(damage);
        yield return new WaitForSeconds(atakTimer);
        canAtak = true;

    }
}
