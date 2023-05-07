using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour, Damageable // Used by enemies: "Player is their target"
{
[SerializeField] private float health; // enemy health
[SerializeField] private bool enemyHasGun; // Some aliens don't have guns
[SerializeField] private float collisionDamage; // Some aliens do damage through collison
[SerializeField] private bool allowCollision; // Check if alien can do collison damage
[SerializeField] private float gunDamage; // damage enemies gun does
[SerializeField] private float range; // how far the enemy range is
[SerializeField] private Transform gunMuzzle;
[SerializeField] private ParticleSystem muzzleFlash;
[SerializeField] private Animator animator;
private AudioSource gunAudio;
//private const string IsShot = "IsShot";
//private const string CanShoot = "CanShoot";
//private const string IsDead = "IsDead";

//public GameObject enemy;
private GameObject enemy;

private bool damagePlayer = true; // Set if player is able to be shot at after given time

private void Start()
{
  gunAudio = GetComponent<AudioSource>();
}

private void Update() {
  //Debug.DrawRay(gunMuzzle.position, gunMuzzle.forward); // Display where gun is aiming
  Debug.DrawRay(transform.position, transform.forward); // Display where gun is aiming
  if (health > 0)
  {
    ShootPlayer();
  }

}

  public void Damage(float damage) // damage
  {
    health -= damage; // Subtract enemy health by damage

    if (health <= 0) // If enemy has 0 health
    {
      //StartCoroutine(ShootGun()); // TEST!!!!
      Destroy(this.gameObject); // Destroy enemy
    //   DestroyEnemy(); // Destroy the enemy
    }
  }


  private void ShootPlayer() // public
  {
  if (enemyHasGun) { // If enemy has a gun
    // https://docs.unity3d.com/ScriptReference/Ray-ctor.html
    //Ray enemyRay = new Ray(gunMuzzle.position, transform.forward);
    Ray enemyRay = new Ray(transform.position, transform.forward);

    RaycastHit hit;

    // if (Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hit, range))
    if (Physics.Raycast(enemyRay, out hit, range)) { // If enemy is in range
      //  animator.SetBool(CanShoot, true);

       if (hit.collider.CompareTag("Player")) // Hit collider on player
      // if (hit.collider.Equals("Player"))
        {
          if (damagePlayer) { // If enemey can shoot
            Damageable damagable = hit.transform.GetComponent<Damageable>(); // make it damagable
            damagable?.Damage(gunDamage); // set damage to gunDamage
            gunAudio.Play(); // play gun shooting audio

            if (muzzleFlash.isPlaying) { // if animation is already playing
              muzzleFlash.Stop();
            }
            // Remove ammo that was fired, set when you last shot to 0, call gun shot method.
            muzzleFlash.Play(); // play gun muzzle animation

            StartCoroutine(ShootGun());
            }
          }
        }
     }
   }


   void OnCollisionEnter(Collision collide) // Check for enemy collison with player
  {
      if (collide.collider.CompareTag("Player") && allowCollision) // if enemy collides with player
      {
       Damageable damagable = collide.transform.GetComponent<Damageable>();
       damagable?.Damage(collisionDamage); // set damage to collisionDamage
       StartCoroutine(CollisonDamage());
      }
    }


 IEnumerator ShootGun() // Used for gun
  {
    damagePlayer = false;

    //enemy.GetComponent<PlayerVitals>().PlayerDamaged(gunDamage); // Damage player

    yield return new WaitForSeconds(1f); // Wait one second to fire

    //animator.SetBool(CanShoot, false);

    damagePlayer = true;
  }

  IEnumerator CollisonDamage() // Used for collison
   {
     allowCollision = false;

     yield return new WaitForSeconds(1f); // Wait one second to damage

     allowCollision = true;
   }


/*

   IEnumerator DestroyEnemy() // Used for death animation
    {
      animator.SetBool(IsDead, true); // death animation

      yield return new WaitForSeconds(2f);

      Destroy(gameObject); // Destroy enemy
    }

*/







}
