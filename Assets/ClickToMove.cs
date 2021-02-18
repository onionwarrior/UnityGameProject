using UnityEngine;
using System.Collections;
using System;
public class ClickToMove : MonoBehaviour
{
	private Transform myTransform;              // this transform
	private Vector3 destinationPosition;        // The destination Point
	private float destinationDistance;          // The distance between myTransform and destinationPosition

	public float moveSpeed;                     // The Speed the character will move
	private CharacterController _charController;
	private Transform myCamera;

	void Start()
	{
		_charController = GetComponent<CharacterController>();
		myTransform = transform;                            // sets myTransform to this GameObject.transform
		destinationPosition = myTransform.position;         // prevents myTransform reset
		myCamera = Camera.main.transform;
	}

	void Update()
	{
		destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);
		if (destinationDistance > .5f)
		{           
			moveSpeed = 6;
		}
		RaycastHit OnClickHit;
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0) && GUIUtility.hotControl == 0)
        {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out OnClickHit)){
				Vector3 TargetPoint = OnClickHit.point;
				//Vector3 DbgPoint = TargetPoint;
				//DbgPoint.y = 10;
				//Ray DbgRay = new Ray(DbgPoint, Vector3.down);
				//Physics.Raycast(DbgRay);
				//Немного пофиксить проницаемость
				TargetPoint.y = myTransform.position.y;
				destinationPosition = TargetPoint;
				Quaternion TargetRotation = Quaternion.LookRotation(TargetPoint - transform.position);
				myTransform.rotation = TargetRotation;
				//Debug.DrawRay(DbgRay.origin, DbgRay.direction * 100,Color.red,20.0f);
			}
        }
		if (destinationDistance > .5f)
		{
			Vector3 dir = destinationPosition - myTransform.position;
			dir.y = -10.0f;
			Vector3 move=  dir.normalized * moveSpeed * Time.deltaTime;
			move.y = -10.0f;
			if (move.magnitude > dir.magnitude) 
				move = dir;
			_charController.Move(move);
		}
	}

}
