using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public static float AmmoInPocket;
    public float reloadCoolDown;
    public float AmmoInGun;
    public float AmmoMax;
    float reloadTimer;
    public float damage = 20f;
    public float gunCoolDown;
    public float range;
    float addableAmmo;
    float gunTimer;
    /*******/
    public Text AmmoCounter;
    public Text pocketAmmoCounter;
    /*******/
    EnemyHealth enemy;
    RaycastHit hit;
    public GameObject RayPoint;
    public GameObject impactEffect, bloodEffect;
    public CharacterController karakter;
    Animator anim;
    public bool canFire;
    /*******/
    public ParticleSystem muzzleFlash;
    /*******/
    AudioSource sesKaynak;
    public AudioClip fireSound, reloadSound;

    void Start()
    {
        sesKaynak = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        AmmoCounter.text = AmmoInGun.ToString();
        pocketAmmoCounter.text = AmmoInPocket.ToString();

        addableAmmo = AmmoMax - AmmoInGun;
        if (addableAmmo > AmmoInPocket)
        {
            addableAmmo = AmmoInPocket;
        }
        if (Input.GetKeyDown(KeyCode.R) && addableAmmo > 0 && AmmoInPocket > 0)
        {
            if (Time.time > reloadTimer)
            {
                StartCoroutine(Reload());
                reloadTimer = Time.time + reloadCoolDown;
            }
        }
        anim.SetFloat("hiz", karakter.velocity.magnitude);
        if (Input.GetKey(KeyCode.Mouse0) && canFire == true && Time.time > gunTimer && AmmoInGun > 0)
        {
            Fire();
            gunTimer = Time.time + gunCoolDown;
        }
    }
    void Fire()
    {
        AmmoInGun--;
        if (Physics.Raycast(RayPoint.transform.position, RayPoint.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Enemy")
            {
                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
                enemy.ReduceHealt(damage);
                Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
            else
            {
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }
            muzzleFlash.Play();
            sesKaynak.Play();
            anim.Play("Muzzle", -1, 0f);
            sesKaynak.clip = fireSound;
        }
    }
    IEnumerator Reload()
    {
        anim.SetBool("isReloading", true);
        sesKaynak.clip = reloadSound;
        sesKaynak.Play();

        yield return new WaitForSeconds(0.3f);
        anim.SetBool("isReloading", false);

        yield return new WaitForSeconds(1.4f);
        AmmoInGun = AmmoInGun + addableAmmo;
        AmmoInPocket = AmmoInPocket - addableAmmo;
    }
}
