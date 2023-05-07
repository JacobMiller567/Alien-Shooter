using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour, Damageable
{
  public GameObject player;
  private PlayerVitals playerHP;
  private bool allowCollision = true;
  private float collisionDamage = 10f;

  public void Damage(float damage) // damage
  {
  //  player.playerHealth -= damage;
    //damage = CollisonDamage;
    playerHP.Damage(collisionDamage);
  //  player.playerHealth.Damage(damage);

  }


    void OnCollisionEnter(Collision collide) // Check for enemy collison with player
    {
        if (collide.collider.CompareTag("Player") && allowCollision) // if enemy collides with player
        {
         playerHP.playerHealth -= collisionDamage;
         Debug.Log("Collison");
         Damageable damagable = collide.transform.GetComponent<Damageable>();
         damagable?.Damage(collisionDamage); // set damage to collisionDamage
         StartCoroutine(CollisonDamage());
        }
      }

      IEnumerator CollisonDamage() // Used for collison
       {
         allowCollision = false;
         yield return new WaitForSeconds(0.5f);
         allowCollision = true;
       }

}
