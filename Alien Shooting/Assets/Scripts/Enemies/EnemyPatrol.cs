using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour // Some enemies will follow a path
{
  //[SerializeField] private Rigidbody rb;
  [SerializeField] private float speed;
  [SerializeField] private Transform player;
  [SerializeField] private Animator animator;
  public Transform[] waypoints;
  private int currentWaypoint = 0;
  private bool moveEnemy = true;
  private bool playerFound = false;
  private float detectionRange = 12f;
  private float detectionAngle = 90f; // 90 degrees
  private float detectionSatisfaction = 2f;

  private const string IsMoving = "IsMoving";
	private const string CanShoot = "CanShoot";

  public NavMeshAgent enemyMeshAgent;
  //public EnemyMovement enemyMove;

  private void Update()
  {
    Transform way_points = waypoints[currentWaypoint];
    animator.SetBool(IsMoving, enemyMeshAgent.velocity.magnitude > 0.02f); // If velocity above .02, then enemy is moving
    animator.SetBool(CanShoot, playerFound); // when in detection range change animation to shooting
    if (moveEnemy) {
      if (findPlayer(player)) // if player is spotted
      {
        //playerFound = true;
        Vector3 playerDirection = (player.position - transform.position);
    		// If we haven't reached the target yet
    		if (playerDirection.magnitude > detectionSatisfaction && playerFound) {
    			// Normalize vector to get just the direction
    			playerDirection.Normalize ();
    			playerDirection *= speed;
         transform.LookAt(playerDirection);
         enemyMeshAgent.SetDestination(playerDirection);
    		}
      //  animator.SetBool(CanShoot, false); // Change back to moving animation
     }
        StartCoroutine(NextWaypoint());
     if (Vector3.Distance(transform.position, way_points.position) < 1f && !playerFound) // If enemy reaches waypoint
       {
           currentWaypoint = (currentWaypoint + 1) % waypoints.Length; // Change to next waypoint
       }

       else
       {

           transform.LookAt(way_points.position);
           enemyMeshAgent.SetDestination(way_points.position); // set destination
       }
     }

   }



public bool findPlayer(Transform player)
{
  if (Vector3.Distance(transform.position, player.position) < detectionRange)
    {
      Vector3 playerDirection = (player.position - transform.position).normalized;
      float angleOfPlayer = Vector3.Angle(transform.forward, playerDirection);

      // if (angleOfPlayer < detectionAngle / 2) // limits view angle and distance
        if (angleOfPlayer < detectionAngle) // limits view angle and distance
      {

        Debug.Log("Player seen angle " + detectionAngle);
        playerFound = true;
        return true;

    //      if (!Physics.Linecast(transform.position, player.position))
    //       {

    //         return true;
            }
  //      }
      }
        playerFound = false;
        return false;
   }



  IEnumerator NextWaypoint()
   {
     moveEnemy = false;


     yield return new WaitForSeconds(3f); // Wait 3 seconds then move to next way point

     moveEnemy = true;
   }





}
