using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class KeyPickup : MonoBehaviour
{
  [SerializeField] public bool masterKey;
  public float PickupRadius = 1f;
  private SphereCollider keyCollider;
  public UnlockDoor key;

  private void Awake()
  {
    keyCollider = GetComponent<SphereCollider>();
    keyCollider.isTrigger = true;
    keyCollider.radius = PickupRadius;
  }

  private void OnTriggerEnter(Collider other)
  {
    key.hasKey = true;
    if (masterKey == true) {
      key.hasMasterKey = true;
    }
    Debug.Log("Key has been picked up!");
    Destroy(this.gameObject);
  }

}
