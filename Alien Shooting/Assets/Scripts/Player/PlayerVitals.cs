using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVitals : MonoBehaviour, Damageable
{
//[SerializeField] private float playerHealth;
[SerializeField] public float playerHealth;
public HealthBar healthBar;
public float maxHealth;
//public AmmoBar ammo;
//private Text text;
//private float playerHealth;
//public MouseMovement mouse;
void Start(){

  maxHealth = playerHealth;
}

  public void Damage(float damage) // damage
  {
    playerHealth -= damage;
  }

  void Update()
  {
      healthBar.DisplayHealth(playerHealth);

      if (playerHealth <= 0) // If player has 0 health
      {
        Cursor.lockState = CursorLockMode.None;
        //Destroy(gameObject); // Destroy player
        SceneManager.LoadScene("GameOver"); // Go to Death screen

      }

  }

}
