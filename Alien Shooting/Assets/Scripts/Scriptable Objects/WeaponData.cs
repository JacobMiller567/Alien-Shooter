using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun")]
public class WeaponData : ScriptableObject, ISerializationCallbackReceiver
{
    public new string name;

    public float damage;
    public float maxRange;
    public int ammo;
    public int magazineSize;
    public float fireRate;
    public float reloadSpeed;
    public bool reloading;

// Used so scriptable object original value doesn't change
// These values get changed throughout the game but wont save
    [NonSerialized]
    public int RuntimeAmmo;

    [NonSerialized]
    public float RuntimeDamage;



  // Used so that the gun scriptable objects don't keep the players data after death
   public void OnAfterDeserialize()
   {
		   RuntimeAmmo = ammo;
       //RuntimeAmmo = magazineSize;
       RuntimeDamage = damage;
   }

   public void OnBeforeSerialize() { }

}
