using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wander : MonoBehaviour
{
	public Transform[] nodesTranforms;
    public float speed = 5;
	public Vector3[] nodePositions = null;
	public int currentNodeIndex = 0;
	void Start ()
	{
		StoreNodePositions ();
		animator = GetComponent <Animator> ();
	
		animator.Play ("walk");
		InvokeRepeating ("CheckInFront", 1, 1);
	}
	void Update ()
	{
		Debug.DrawLine (transform.position, nodePositions[currentNodeIndex]);

		CheckIfWeReachedNode ();
		// LookTowardsNode ();
		// CheckInFront ();
	}
	public void LookTowardsNode ()
	{
		transform.DOLookAt (nodePositions[currentNodeIndex], 1, AxisConstraint.Y);
	}
	void CheckIfWeReachedNode ()
	{
		float entityX = transform.position.x;
		float entityZ = transform.position.z;
		float nodeX = nodePositions[currentNodeIndex].x;
		float nodeZ = nodePositions[currentNodeIndex].z;
		Vector2 start = new Vector2 (entityX, entityZ);
		Vector2 end = new Vector2 (nodeX, nodeZ);
		
		float distance = Vector2.Distance (start, end);
		if (distance < 0.7f)
		{
			currentNodeIndex++;
			if (currentNodeIndex >= nodePositions.Length)
				currentNodeIndex = 0;
			LookTowardsNode ();
		}
	}
	bool freeze = false;
	IEnumerator TryNextNode ()
	{
		freeze = true;
		currentNodeIndex++;
		if (currentNodeIndex >= nodePositions.Length)
			currentNodeIndex = 0;
		LookTowardsNode ();
		yield return new WaitForSeconds (0);
		freeze = false;
	}
    void CheckInFront ()
	{	
		Vector3 offset = new Vector3 (0, 0.1f, 0);
		RaycastHit[] hit;
		hit = Physics.SphereCastAll (transform.position + Vector3.up / 3 + transform.forward * 0.5f, 0.2f, transform.forward, 0.1f);
		
		for (int i = 0; i < hit.Length; i++)
		{
			// Ignore slef
			if (hit[i].collider.gameObject == gameObject) continue;
			

			// if (hit[i].collider.gameObject.layer == LayerMask.NameToLayer ("Obstacle"))
			if (freeze == false)
				StartCoroutine(TryNextNode());
		}
	}
	void OnDrawGizmos ()
	{
		Gizmos.DrawWireSphere (transform.position + Vector3.up / 3 + transform.forward * 0.5f, 0.2f);
	}
	bool imRotating = false;
	void StoreNodePositions ()
	{
		// Doing this because im keeping the nodeTransforms as a CHILD of this entity
		// and when the entity moves the nodeTransforms move around, so let's store
		// nodeTransform positions as a vector3[] in Start () so I can keep the nodes
		// as a child of the entity to stay close hierarchy
		nodePositions = new Vector3[nodesTranforms.Length];
		for (int i = 0; i < nodesTranforms.Length; i++)
			nodePositions[i] = nodesTranforms[i].position;
	}
	void RandomlyLookAtNodePosition ()
	{
		currentNodeIndex = Random.Range (0, nodePositions.Length);
		transform.DOLookAt (nodePositions[currentNodeIndex], 1, AxisConstraint.Y);
	}
	CharacterController controller;
	Animator animator;
	
}