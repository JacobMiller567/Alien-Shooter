using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
  public void Awake() {
    StartCoroutine(Restart());
  }

  IEnumerator Restart()
   {

     yield return new WaitForSeconds(4f); // restart game after 4 seconds
     SceneManager.LoadScene("MenuScreen");
   }
}
