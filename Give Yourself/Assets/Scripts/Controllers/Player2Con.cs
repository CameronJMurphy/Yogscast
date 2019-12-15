using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Con : Player
{
	public override void Movement()
	{
		
		//player 2 jump
		if (Input.GetKey(KeyCode.UpArrow))
		{
			jumpTimer -= Time.deltaTime;
			if (jumpTimer > 0)
			{
				Jump();
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow) )
		{
			idleAni.flipX = false;
			if (jumpTimer > 0 || grounded)
			{
				MoveLeft();
			}
		}
		if (Input.GetKey(KeyCode.RightArrow ) )
		{
			idleAni.flipX = true;
			if (jumpTimer > 0 || grounded)
			{
				MoveRight();
			}
		}
	}


	public override void DectectHeliumExchange()
	{
		if (Input.GetButtonDown("HeliumSwitch2") && Mathf.Abs(otherPlayer.transform.position.x - transform.position.x) <= heliumBuffer
			&& Mathf.Abs(otherPlayer.transform.position.y - transform.position.y) <= heliumBuffer) //One player loses helium and one player gains helium
		{
			Deflate();
			otherPlayer.Inflate();
		}
	}
}
