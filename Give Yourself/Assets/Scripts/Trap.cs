using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
	private GameCon GC;
	private void Start()
	{
		GC = FindObjectOfType<GameCon>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			GC.ResetLevel();
		}
	}
}
