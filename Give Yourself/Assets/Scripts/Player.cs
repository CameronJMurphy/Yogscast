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
	[SerializeField] private float jumpSpeed;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float airMoveSpeed;
	[SerializeField] private float timerDecaySpeed;
	[SerializeField] private float maxVelocity;
	public bool grounded = false;
	public float heliumBuffer;


	public Text heliumText;
	public Slider heliumBar;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		jumpTimer = Helium / timerDecaySpeed;
	}
	public void Jump()
	{		
		rb.velocity = new Vector3(rb.velocity.x, 1 * jumpSpeed, 0);
	}

	public void MoveLeft()
	{
		if (grounded)
		{
			rb.velocity = new Vector3(-1 * moveSpeed, rb.velocity.y, 0); // on ground ms
		}
		else
		{
			rb.velocity = new Vector3(-1 * airMoveSpeed, rb.velocity.y, 0); //in the air ms
		}
	}
	public void MoveRight()
	{
		if (grounded)
		{
			rb.velocity = new Vector3(1 * moveSpeed, rb.velocity.y, 0); // on ground ms
		}
		else
		{
			rb.velocity = new Vector3(1 * airMoveSpeed, rb.velocity.y, 0); // in the air ms
		}
	}

	public void Deflate()
	{
		if (Helium > 1)
		{
			--Helium;
			jumpTimer = Helium / timerDecaySpeed;
		}

	}

	public void Inflate()
	{
		if (Helium < 11)
		{
			++Helium;
			jumpTimer = Helium / timerDecaySpeed;
		}

	}

	void FixedUpdate()
	{
		Movement();
		displayHelium();
		DectectHeliumExchange();

	}

	virtual public void Movement()
	{
		
		if (Input.GetKey(KeyCode.W)) //jump
		{
			jumpTimer -= Time.deltaTime;
			if (jumpTimer > 0)
			{
				Jump();
			}
		}
		if (Input.GetKey(KeyCode.A)) //left
		{
			if (jumpTimer > 0 || grounded)
			{
				MoveLeft();
			}
		}
		if (Input.GetKey(KeyCode.D)) //right
		{
			if (jumpTimer > 0 || grounded)
			{
				MoveRight();
			}
		}
	}

	public virtual void DectectHeliumExchange()
	{
		
		if (Input.GetButtonDown("HeliumSwitch1") && Mathf.Abs(otherPlayer.transform.position.x - transform.position.x) <= heliumBuffer
			&& Mathf.Abs(otherPlayer.transform.position.y - transform.position.y) <= heliumBuffer) //One player loses helium and one player gains helium
		{
			Deflate();
			otherPlayer.Inflate();
		}
		

	}

	private void OnTriggerStay(Collider other)
	{
		if (!other.gameObject.CompareTag("Player"))
		{
			jumpTimer = Helium / timerDecaySpeed; //reset timer allowing player to jump
			grounded = true;
		}

	}
	private void OnTriggerExit(Collider other)
	{
		grounded = false;
	}

	private void displayHelium()
	{
		int maxHelium = 11;
		float maxTimer = maxHelium / timerDecaySpeed;
		heliumText.text = (Helium -1).ToString();
		heliumBar.value = jumpTimer / maxTimer;
	}

}
