using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private WeaponData gunData;
    [SerializeField] private Transform muzzle;
    [SerializeField] private ParticleSystem muzzleFlash;
    private AudioSource gunAudio;

    float timeLastShot;

    private void Start()
    {
      PlayerShooting.inputShooting += Shoot;
      PlayerShooting.inputReloading += Reloading;
      gunAudio = GetComponent<AudioSource>();
    }

    public void Reloading()
    {
      if (!gunData.reloading)
      {
        StartCoroutine(Reload());
      }
    }
    private IEnumerator Reload()
    {
      gunData.reloading = true;

      yield return new WaitForSeconds(gunData.reloadSpeed);

      //gunData.ammo = gunData.magazineSize;
      gunData.RuntimeAmmo = gunData.magazineSize;
      //gunData.RuntimeAmmo = gunData.ammo;


      // Stop reloading
      gunData.reloading = false;
    }


    private bool CanShoot () => !gunData.reloading && timeLastShot > 1f / (gunData.fireRate / 60f); //

    public void Shoot()
    {

      // if (gunData.ammo > 0)
      if (gunData.RuntimeAmmo > 0)
      {
        if (CanShoot())
        {
          if (Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hitInfo, gunData.maxRange))
          {
            gunAudio.Play();
            Damageable damagable = hitInfo.transform.GetComponent<Damageable>();
            //damagable?.Damage(gunData.damage);
            damagable?.Damage(gunData.RuntimeDamage); // use RuntimeDamage so damage doesn't stack when you restart
          }
          if (muzzleFlash.isPlaying) { // if animation is already playing
            muzzleFlash.Stop();
          }
          // Remove ammo that was fired, set when you last shot to 0, call gun shot method.
          muzzleFlash.Play(); // play gun muzzle animation
        //  gunData.ammo--;
          gunData.RuntimeAmmo--;
          timeLastShot = 0;

          GunShot();
        }
      }
    }

    private void Update()
    {
      timeLastShot += Time.deltaTime;
      Debug.DrawRay(muzzle.position, muzzle.forward); // Display where gun is aiming

    }




      private void GunShot(){
      }

}
