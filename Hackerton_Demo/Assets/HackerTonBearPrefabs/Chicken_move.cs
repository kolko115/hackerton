using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Chicken_move : MonoBehaviour
{
	[SerializeField] private string animalName; // 동물의 이름
	[SerializeField] private float walkSpeed; // 이동 속도(걷기)

	private Vector3 direction;

	private bool isAction; // 행동중인지 아닌지
	private bool isRunning; // 걷는지 안 걷는지

	[SerializeField] private float walkTime;  // 걷기 시간
	[SerializeField] private float waitTime; // 대기 시간
	private float currentTime;

	[SerializeField] private Animator anim;
	[SerializeField] private Rigidbody rigid;
	[SerializeField] private BoxCollider boxCol;

	// Start is called before the first frame update
	void Start()
	{
		currentTime = waitTime;
		isAction = true;
	}

	// Update is called once per frame
	void Update()
	{
		ElapseTime();
		Rotation();
		Move();
	}

	private void Move()
	{
		if (isRunning)
		{
			rigid.MovePosition(transform.position + (transform.forward * walkSpeed * Time.deltaTime));
		}
	}

	private void Rotation()
	{
		if (isRunning)
		{
			Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, direction, 0.03f);
			rigid.MoveRotation(Quaternion.Euler(_rotation));
		}
	}

	private void ElapseTime()
	{
		if (isAction)
		{
			currentTime -= Time.deltaTime;
			if (currentTime <= 0)
			{
				ReSet();
			}
		}
	}

	private void ReSet()
	{
        isRunning = false;
		isAction = true;

		anim.SetBool("Running", isRunning);
		direction.Set(0f, Random.Range(0f, 360f), 0f);

		RandomAction();
	}
	private void RandomAction()
	{
		int _random = Random.Range(0, 3);

		Debug.Log(_random);

		switch (_random)
		{
			case 0: // 대기
				Wait();
				break;
			case 1: // 먹기
				TryWalk();
				break;
			case 2: // 뛰기
				Eat();
				break;
		}
	}

	private void Wait()
	{
		currentTime = waitTime; // 0.1
	}

	private void Eat()
	{
		currentTime = 2.48f;
		anim.SetTrigger("Eat");
	}

	private void TryWalk()
	{
        isRunning = true;
		currentTime = walkTime;
		anim.SetBool("Running", isRunning);
	}
}