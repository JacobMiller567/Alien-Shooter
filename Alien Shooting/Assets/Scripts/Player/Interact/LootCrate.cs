using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class LootCrate : MonoBehaviour
{
  private Animation animate;
  private float interactRadius = 1f;
  private SphereCollider collider;
  private float lootHealth = 25f;
  public PlayerVitals currentHealth;
  public WeaponData weapon;
  private int lootAmmo = 12;
  private float lootDamage = 5f;



  private void Awake()
  {
      animate = gameObject.GetComponent<Animation>();
      collider = GetComponent<SphereCollider>();
      collider.isTrigger = true;
      collider.radius = interactRadius;
  }


  private void OnTriggerEnter(Collider other)
  {
    animate.Play("Crate_Open"); // open the crate
    LootSpin();
    StartCoroutine(CloseCrate());
  }

  IEnumerator CloseCrate()
  {
    yield return new WaitForSeconds(2f); // keep crate open for 2 seconds
    animate.Play("Crate_Close"); // close the crate
    yield return new WaitForSeconds(1f); // wait 1 second
    Destroy(this.gameObject); // destroy crate
  }


  private void LootSpin() {
    float randomNumber = Random.Range(0, 100); // random number between 0 and 1

    if (randomNumber > 50) // 50% chance of pulling health boost
    {
      Debug.Log("50% chance: Ammo has been added");
      weapon.RuntimeAmmo += lootAmmo;
    }
    if (randomNumber < 40) // 40% chance of pulling health boost
    {
      Debug.Log("40% chance: Health applied");
      currentHealth.playerHealth += lootHealth;
    }
    if (randomNumber >= 40 && randomNumber <= 50)
    {
      Debug.Log("10% chance: Gun damage increased");
      weapon.RuntimeDamage += lootDamage;
    }


  }




}
