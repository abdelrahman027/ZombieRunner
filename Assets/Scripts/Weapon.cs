using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
[SerializeField] Camera FPScam;
[SerializeField] float Range = 100f;
[SerializeField] float Damage =30f;
[SerializeField] ParticleSystem muzzleFlash;
[SerializeField] GameObject hitEffect;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            muzzleFlash.Stop();
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();
        muzzleFlash.time = 1f;
        processRaycast();
    }

    void processRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPScam.transform.position, FPScam.transform.forward, out hit, Range))
        {
            CreateImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.PlayerHit(Damage);
        }

        else
        { return; }
    }
    void CreateImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect,hit.point,Quaternion.LookRotation(hit.normal));

        Destroy(impact,1f);
    }
}
