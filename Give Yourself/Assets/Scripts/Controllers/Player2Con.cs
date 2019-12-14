using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Con : Player
{
	public override void Movement()
	{
		jumpTimer -= Time.deltaTime;
		//player 2 jump
		if (Input.GetKey(KeyCode.UpArrow))
		{
			if (jumpTimer > 0)
			{
				Jump();
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (jumpTimer > 0)
			{
				MoveLeft();
			}
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			if (jumpTimer > 0)
			{
				MoveRight();
			}
		}
	}

	public override void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (Input.GetButtonDown("HeliumSwitch2")) //player2 loses helium and player 1 gains helium
			{
				Deflate();
				otherPlayer.Inflate();
			}
		}
	}
}
