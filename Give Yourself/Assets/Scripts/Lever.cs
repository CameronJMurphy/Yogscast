using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
	bool Activated = false;
	[SerializeField] List<IActivatable> activatables;
	private void Start()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (Activated == false)
		{
			Activated = true;
			foreach (IActivatable activatable in activatables)
			{
				activatable.Activate();
				Debug.Log("Activated");
			}
		}
		else
		{
			Activated = false;
			foreach (IActivatable activatable in activatables)
			{
				activatable.Deactivate();
				Debug.Log("Deactivated");
			}
		}
	}
}
