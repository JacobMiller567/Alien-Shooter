using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
  public WeaponData weapon;
  public Text ammoText;
  //private PlayerVitals player;
  public int maxAmmo;
  public int getAmmo;

/*  void Start()
    {
     ammoText = GetComponent<Text>();
     maxAmmo = weapon.magazineSize; // get max ammo maxValue
     getAmmo = weapon.ammo;
    }

    */

    void Update()
    {
      ammoText = GetComponent<Text>();
      maxAmmo = weapon.magazineSize; // get max ammo maxValue
      //getAmmo = weapon.ammo;
      getAmmo = weapon.RuntimeAmmo;
      ammoText.text = "Ammo: " + getAmmo + "/" + maxAmmo;
    }

//    public void DisplayAmmo(int ammunition)
//    {
//        getAmmo = ammunition;
//        ammoText.text = "Ammo: " + getAmmo;
//    }




}
