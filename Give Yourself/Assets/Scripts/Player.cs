using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public int Helium;
	private Rigidbody rb;
	public Player otherPlayer;
	public float jumpTimer;
	private int jumpSpeed = 2;
	private int moveSpeed = 5;

	public Text heliumText;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		jumpTimer = Helium / 2;
	}
	public void Jump()
	{
		rb.velocity = Vector3.up * jumpSpeed;
	}

	public void MoveLeft()
	{
		rb.velocity = new Vector3(-1 * moveSpeed, -.5f, 0);
	}
	public void MoveRight()
	{
		rb.velocity = new Vector3(1 * moveSpeed, -.5f, 0);
	}

	public void Deflate()
	{
		if (Helium > 1)
		{
			--Helium;
			jumpTimer = Helium / 2;
		}

	}

	public void Inflate()
	{
		if (Helium < 11)
		{
			++Helium;
			jumpTimer = Helium / 2;
		}

	}
	// Update is called once per frame
	void FixedUpdate()
	{
		Movement();
		displayHelium();
	}

	virtual public void Movement()
	{
		jumpTimer -= Time.deltaTime;
		if (Input.GetKey(KeyCode.W)) //jump
		{
			if (jumpTimer > 0)
			{
				Jump();
			}
		}
		if (Input.GetKey(KeyCode.A)) //left
		{
			MoveLeft();
		}
		if (Input.GetKey(KeyCode.D)) //right
		{
			MoveRight();
		}
	}

	virtual public void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (Input.GetButtonDown("HeliumSwitch1")) //player2 loses helium and player 1 gains helium
			{
				Deflate();
				otherPlayer.Inflate();
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (!other.gameObject.CompareTag("Player"))
		{
			jumpTimer = Helium / 2; //reset timer allowing player to jump
		}

	}

	private void displayHelium()
	{
		heliumText.text = (Helium -1).ToString();
	}

}
