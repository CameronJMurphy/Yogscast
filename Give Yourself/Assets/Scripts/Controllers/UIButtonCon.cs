using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonCon : MonoBehaviour
{
	public delegate void StartGame();
	public static event StartGame startGame;

	public void StartGameButtonPress()
	{
		startGame();
	}

}
