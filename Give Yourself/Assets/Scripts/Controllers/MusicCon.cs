using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCon : MonoBehaviour
{
	public static MusicCon instance;
	private float musicVolume = 1;
	private float FXVolume = 1;
	// Start is called before the first frame update
	void Start()
    {
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(this);
		UICon.volumeChange += VolumeChange;
		UICon.fXVolumeChange += FXVolumeChange;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void VolumeChange(float vol)
	{
		musicVolume = vol;
		Debug.Log(musicVolume);
	}

	private void FXVolumeChange(float FXVol)
	{
		FXVolume = FXVol;
		Debug.Log(FXVolume);
	}
}
