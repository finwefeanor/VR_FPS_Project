using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleFire : MonoBehaviour {

    [SerializeField] float fireDamage = 10f;
    [SerializeField] float rifleImpactForce;
    [SerializeField] float range = 100f;
    [SerializeField] float fireRate = 15f;
    [SerializeField] float reloadTime = 1f;
    [SerializeField] int maxAmmo = 10;

    [SerializeField] public Camera fpsCam;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject impactEffect;
    [SerializeField] Animator animator;

    [SerializeField] AudioClip shotSound;
    [SerializeField] AudioClip reloadSound;
    [SerializeField] GameObject[] bulletTex;

    FlashLight reloadScript;

    public int currentAmmo;

    private float nextTimeToFire = 0f;
    private bool isReloading = false;
    float timer;   

    void Start() 
    {
        currentAmmo = maxAmmo;   
    }

    void OnEnable() {
        isReloading = false;
        animator.SetBool("ReloadingAnim", false);
    }

    void Update() 
    {
       if (isReloading) { return; }

        if (currentAmmo <= 0)
        {
            StartCoroutine(ReloadWeapon());
            return; // return from here to not to shoot while reloading
        }

        if ((currentAmmo < maxAmmo) && (Input.GetButton("Fire2") ||
            (fpsCam.transform.eulerAngles.z >= 20f && fpsCam.transform.eulerAngles.z < 90f))) // Reloads gun when we change the roll of the phone to both sides
        {
            StartCoroutine(ReloadWeapon());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {            
            nextTimeToFire = Time.time + 1f / fireRate;
            PlayShotSound();
            Shoot();       
        }
    }    

    IEnumerator ReloadWeapon() {
        isReloading = true;
        Debug.Log("Reloading weapon");

        animator.SetBool("ReloadingAnim", true);
        PlayReloadSound();
        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("ReloadingAnim", false);
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;

        isReloading = false;
    }

    public void Shoot() 
    {
        currentAmmo--;      

        Debug.Log("currentammo:" + currentAmmo);
        muzzleFlash.Play();
        RaycastHit hit;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {            
            EnemyTarget enemyTarget = hit.transform.GetComponent<EnemyTarget>(); // convert this to abstract class

            if (enemyTarget != null)
            {
                enemyTarget.KillDamage(fireDamage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * rifleImpactForce);
            }

            GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGameObject, 1.4f);

            GameObject bulletObject = Instantiate(bulletTex[UnityEngine.Random.Range(0, 2)], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            bulletObject.transform.parent = hit.transform; // we made bullets the children of the object they hit, so there will be no floating bullet texture on dynamic objects.
            Destroy(bulletObject, 2f);
        }

    }

    private void PlayShotSound() 
    {
        AudioSource audioSource = GetComponentInParent<AudioSource>();
        audioSource.PlayOneShot(shotSound);
    }

    private void PlayReloadSound() {
        AudioSource audioSource = GetComponentInParent<AudioSource>();
        audioSource.PlayOneShot(reloadSound);
    }

}
