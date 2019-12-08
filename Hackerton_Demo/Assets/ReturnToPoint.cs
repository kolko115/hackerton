using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ReturnToPoint : MonoBehaviour
{
    public Transform snapTo;
	public Transform snapTo2;
	private Rigidbody body;
    public float snapTime = 2;

	private float dropTimer;
    private Interactable interactable;
    private float distanceofpoint;
	private float distanceofpoint2;

	private void Start()
    {
        interactable = GetComponent<Interactable>();
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        distanceofpoint = Vector3.Distance(snapTo.transform.position, this.transform.position);
		distanceofpoint2 = Vector3.Distance(snapTo2.transform.position, this.transform.position);
		//Debug.Log(snapTo.transform.position);
		//Debug.Log(this.transform.position);
        //Debug.Log(distanceofpoint);
		//Debug.Log(snapTo2.transform.position);
		//Debug.Log(this.transform.position);
		//Debug.Log(distanceofpoint2);
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
		}
        
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ReturnToPoint : MonoBehaviour
{
	public Transform[] snapTo;
	private Rigidbody body;
	public float snapTime = 2;

	private float dropTimer;
	private Interactable interactable;
	private float[] distanceofpoint;

	private void Start()
	{
		interactable = GetComponent<Interactable>();
		body = GetComponent<Rigidbody>();
	}

	void Update()
	{
		for(int i=0; i<snapTo.Length; i++)
			distanceofpoint[i] = Vector3.Distance(snapTo[i].transform.position, this.transform.position);
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

			for (int i = 0; i < snapTo.Length; i++)
			{
				if (distanceofpoint[i] < 0.3)
				{


					if (dropTimer > 1)
					{
						//transform.parent = snapTo;
						transform.position = snapTo[i].position;
						transform.rotation = snapTo[i].rotation;
					}
					else
					{
						float t = Mathf.Pow(35, dropTimer);

						body.velocity = Vector3.Lerp(body.velocity, Vector3.zero, Time.fixedDeltaTime * 4);
						if (body.useGravity)
							body.AddForce(-Physics.gravity);

						transform.position = Vector3.Lerp(transform.position, snapTo[i].position, Time.fixedDeltaTime * t * 3);
						transform.rotation = Quaternion.Slerp(transform.rotation, snapTo[i].rotation, Time.fixedDeltaTime * t * 2);
					}
				}
			}
		}

	}
}
*/