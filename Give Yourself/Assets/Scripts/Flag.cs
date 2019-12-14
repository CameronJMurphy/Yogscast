using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
	List<Player> playersAtEnd;

	private void Start()
	{
		playersAtEnd = new List<Player>();
	}
	private void OnTriggerEnter(Collider other)
	{
		foreach (Player player in playersAtEnd)
		{
			if (player != other.gameObject.GetComponent<Player>())
			{
				playersAtEnd.Add(other.gameObject.GetComponent<Player>());
				break;
			}
		}
		if (other.gameObject.CompareTag("Player"))
		{
			if( playersAtEnd.Count == 0)
			{
				playersAtEnd.Add(other.gameObject.GetComponent<Player>());
			}
		}

		if(playersAtEnd.Count == 2)
		{
			GameCon GC = FindObjectOfType<GameCon>();
			GC.NextLevel();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			playersAtEnd.Remove(other.gameObject.GetComponent<Player>());
		}
	}




}
