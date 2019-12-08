using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ReturnToPoint3 : MonoBehaviour
{
	public Transform snapTo;
	public Transform snapTo2;
	public Transform snapTo3;
	private Rigidbody body;
	public float snapTime = 2;

	private float dropTimer;
	private Interactable interactable;
	private float distanceofpoint;
	private float distanceofpoint2;
	private float distanceofpoint3;

	private void Start()
	{
		interactable = GetComponent<Interactable>();
		body = GetComponent<Rigidbody>();
	}

	void Update()
	{
		distanceofpoint = Vector3.Distance(snapTo.transform.position, this.transform.position);
		distanceofpoint2 = Vector3.Distance(snapTo2.transform.position, this.transform.position);
		distanceofpoint3 = Vector3.Distance(snapTo3.transform.position, this.transform.position);
	}

	private void FixedUpdate()
	{
		bool used = false;

		if (interactable != null)
			used = interactable.attachedToHand;


		if (used)
		{
			body.isKinematic = false;
			dropTimer = -1;
		}
		else
		{
			dropTimer += Time.deltaTime / (snapTime / 2);

			body.isKinematic = dropTimer > 1;

			if (distanceofpoint < 0.3)
			{


				if (dropTimer > 1)
				{
					//transform.parent = snapTo;
					transform.position = snapTo.position;
					transform.rotation = snapTo.rotation;
				}
				else
				{
					float t = Mathf.Pow(35, dropTimer);

					body.velocity = Vector3.Lerp(body.velocity, Vector3.zero, Time.fixedDeltaTime * 4);
					if (body.useGravity)
						body.AddForce(-Physics.gravity);

					transform.position = Vector3.Lerp(transform.position, snapTo.position, Time.fixedDeltaTime * t * 3);
					transform.rotation = Quaternion.Slerp(transform.rotation, snapTo.rotation, Time.fixedDeltaTime * t * 2);
				}
			}
			else if (distanceofpoint2 < 0.3)
			{


				if (dropTimer > 1)
				{
					//transform.parent = snapTo;
					transform.position = snapTo2.position;
					transform.rotation = snapTo2.rotation;
				}
				else
				{
					float t = Mathf.Pow(35, dropTimer);

					body.velocity = Vector3.Lerp(body.velocity, Vector3.zero, Time.fixedDeltaTime * 4);
					if (body.useGravity)
						body.AddForce(-Physics.gravity);

					transform.position = Vector3.Lerp(transform.position, snapTo2.position, Time.fixedDeltaTime * t * 3);
					transform.rotation = Quaternion.Slerp(transform.rotation, snapTo2.rotation, Time.fixedDeltaTime * t * 2);
				}
			}
			else if (distanceofpoint3 < 0.3)
			{


				if (dropTimer > 1)
				{
					//transform.parent = snapTo;
					transform.position = snapTo3.position;
					transform.rotation = snapTo3.rotation;
				}
				else
				{
					float t = Mathf.Pow(35, dropTimer);

					body.velocity = Vector3.Lerp(body.velocity, Vector3.zero, Time.fixedDeltaTime * 4);
					if (body.useGravity)
						body.AddForce(-Physics.gravity);

					transform.position = Vector3.Lerp(transform.position, snapTo3.position, Time.fixedDeltaTime * t * 3);
					transform.rotation = Quaternion.Slerp(transform.rotation, snapTo3.rotation, Time.fixedDeltaTime * t * 2);
				}
			}
		}

	}
}
