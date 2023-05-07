using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockDoor : MonoBehaviour
{
  [SerializeField] private bool specialLock; // might not be needed now
  public float doorDistance = 1f;
  private SphereCollider doorCollider;
  public bool hasKey = false;
  public bool hasMasterKey = false;
  [SerializeField] private bool winGame;
  //public PlayerVitals currentHealth;

  private void Awake()
  {
    doorCollider = GetComponent<SphereCollider>();
    doorCollider.isTrigger = true;
    doorCollider.radius = doorDistance;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag.Equals("Player")) {
      if (hasKey && !specialLock) {
        Destroy(this.gameObject);
      }
      if(specialLock && hasMasterKey) {
        Destroy(this.gameObject);
      }
      if(winGame && hasKey) {
        SceneManager.LoadScene("WinGame");
        Destroy(this.gameObject);
        //StartCoroutine(FinalDoor());
      }
      else {
        Debug.Log("Door is locked. Key needed!");
        // Future: Display text on screen saying door is locked
      }
    }
  }

/*  IEnumerator FinalDoor()
   {
     yield return new WaitForSeconds(1f); // Wait 3 seconds then move to next way point
     SceneManager.LoadScene("WinGame");

   }
*/

}
