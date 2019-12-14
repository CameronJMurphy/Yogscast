using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	public List<IActivatable> activatables;
	private void Start()
	{
		//activatables = new List<IActivatable>();
	}

	private void OnCollisionStay(Collision collision)
	{
		foreach(IActivatable activatable in activatables)
		{
			activatable.Activate();
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		foreach (IActivatable activatable in activatables)
		{
			activatable.Deactivate();
		}
	}
}
