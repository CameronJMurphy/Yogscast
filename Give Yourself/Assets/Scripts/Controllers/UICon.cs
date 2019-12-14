using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICon : MonoBehaviour
{
	public delegate void StartGame();
	public static event StartGame startGame;

	public delegate void VolumeChange(float vol);
	public static event VolumeChange volumeChange;

	public delegate void FXVolumeChange(float FXVol);
	public static event FXVolumeChange fXVolumeChange;

	public delegate void BackButton();
	public static event BackButton backButton;

	public delegate void OptionsButton();
	public static event OptionsButton optionsButton;

	public void StartGameButtonPress()
	{
		startGame();
	}

	public void VolumeModifier(float vol)
	{
		volumeChange(vol);
	}

	public void FXVolumeModifier(float FXVol)
	{
		fXVolumeChange(FXVol);
	}

	public void BackButtonPress()
	{
		backButton();
	}

	public void OptionsButtonPress()
	{
		optionsButton();
	}
}
