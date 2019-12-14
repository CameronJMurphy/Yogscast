using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeliumCanister : MonoBehaviour
{
	[SerializeField] private int helium = 1;
	public Text heliumText;

	public void FillUp(Player player)
	{
		if (player.Helium > 1)
		{
			player.Helium -= 1;
			helium += 1;
		}
	}

	public void Drain(Player player)
	{
		if (helium > 1)
		{
			player.Helium += 1;
			helium -= 1;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if(Input.GetButtonDown("HeliumSwitch1") || Input.GetButtonDown("HeliumSwitch2"))
			{
				FillUp(other.gameObject.GetComponent<Player>());
			}
			if (Input.GetButtonDown("HeliumDrain"))
			{
				Drain(other.gameObject.GetComponent<Player>());
			}
		}
	}

	private void Update()
	{
		DisplayHelium();
	}
	private void DisplayHelium()
	{
		heliumText.text = (helium-1).ToString();
	}

}
