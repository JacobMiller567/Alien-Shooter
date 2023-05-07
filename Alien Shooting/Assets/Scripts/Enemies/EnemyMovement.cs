using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	[SerializeField] private Transform transform;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private Transform target;
	[SerializeField] private bool meshAgent;
	[SerializeField] private NavMeshAgent enemyMeshAgent;
	//[SerializeField] private bool stationary;
	private const string IsMoving = "IsMoving";
	private const string CanShoot = "CanShoot";

	[SerializeField] private float maxSpeed;
	[SerializeField] private float detectionRange;
	//[SerializeField] private Animation animate;
	[SerializeField]	private Animator animator;
	private float detectionAngle;
	//public bool isPlayerSeen = false;


private	void Start () {
//	animate =	gameObject.GetComponent<Animation>();
		//maxSpeed = 6f;
		//detectionAngle = 90f; // 90 degrees
	}

	// Update is called once per frame
private	void Update () {

animator.SetBool(IsMoving, enemyMeshAgent.velocity.magnitude > 0.02f); // If velocity above .02, then enemy is moving

		// Calculate vector from character to target
		Vector3 towards = target.position - transform.position; // * Time.deltaTime;
		//float angleToTarget = Vector3.Angle(transform.forward, towards);
		//towards.y = transform.position.y;
		Quaternion rotation = Quaternion.LookRotation(towards);

	//	transform.rotation = Mathf.Clamp(rotation.eulerAngles.y, -180.0f, 180.0f);
		//transform.rotation.Set(rotation, 0f, 0f);
		transform.rotation = rotation;

	//	transform.eulerAngles.y = Mathf.Clamp(transform.eulerAngles.y, -90, 90);

	//Vector3 newDirection = Vector3.RotateTowards(towards, singleStep, 0.0f);

	 	if (towards.magnitude < detectionRange) {
			   animator.SetBool(CanShoot, true); // when in detection range change animation to shooting
			// Normalize vector to get just the direction

		//	towards.Normalize ();
		//	towards *= maxSpeed;

			// Move character

			enemyMeshAgent.SetDestination(target.transform.position);
		}
		else
		{
			 animator.SetBool(CanShoot, false);
			// rb.velocity = towards;
		}

}




}
