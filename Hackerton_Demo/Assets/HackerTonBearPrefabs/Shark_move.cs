using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shark_move : MonoBehaviour
{
	[SerializeField] private string animalName; // 동물의 이름
	[SerializeField] private float walkSpeed; // 이동 속도(걷기)

	private Vector3 direction;

	private bool isAction; // 행동중인지 아닌지
	private bool isWalking; // 걷는지 안 걷는지

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
		rigid.MovePosition(transform.position + (transform.forward * walkSpeed * Time.deltaTime));
	}

	private void Rotation()
	{
		if (isWalking)
		{
			Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, direction, 0.01f);
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
		isWalking = false;
		isAction = true;

		anim.SetBool("Walking", isWalking);
		direction.Set(0f, Random.Range(0f, 360f), 0f);

		RandomAction();
	}
	private void RandomAction()
	{
		int _random = Random.Range(0, 2);

		Debug.Log(_random);

		switch (_random)
		{
			case 0: // 대기
				Wait();
				break;
			case 1: // 공격
                TryWalk();
				break;
			case 2: // 걷기
				Attack();
				break;
		}
	}

	private void Wait()
	{
		currentTime = waitTime; // 0.1
	}

	private void TryWalk()
	{
		isWalking = true;
		currentTime = walkTime;
		anim.SetBool("Walking", isWalking);
	}

	private void Attack()
	{
		currentTime = 5.39f;
		anim.SetTrigger("Attack");
	}
}