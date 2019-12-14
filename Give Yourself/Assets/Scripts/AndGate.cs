using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndGate : IActivatable
{
	public bool Activated = false;
	public AndGate partner;
	

	public override void Activate()
	{
		Activated = true;
		if (Activated == true && partner.Activated == true)
		{
			gameObject.SetActive(false);
			partner.gameObject.SetActive(false);
		}
	}

	public override void Deactivate()
	{
		Activated = false;
	}

}
