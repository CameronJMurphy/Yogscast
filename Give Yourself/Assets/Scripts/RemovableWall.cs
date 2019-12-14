using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovableWall : IActivatable
{
	public override void Activate()
	{
		gameObject.SetActive(false);
	}
	public override void Deactivate()
	{
		gameObject.SetActive(true);
	}

}
