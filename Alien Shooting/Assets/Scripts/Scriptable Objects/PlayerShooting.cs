using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static Action inputShooting;
    public static Action inputReloading;

    [SerializeField] private KeyCode reloadKey = KeyCode.R;
    [SerializeField] private AudioSource reloadAudio;

    private void Update()
    {
      if (Input.GetMouseButton(0))
      {
        inputShooting?.Invoke();
      }
      if (Input.GetKeyDown(reloadKey))
      {
        inputReloading?.Invoke();
        reloadAudio.Play();
      }
    }
}
