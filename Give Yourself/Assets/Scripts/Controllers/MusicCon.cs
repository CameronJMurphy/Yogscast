using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicCon : MonoBehaviour
{
	public static MusicCon instance;
	[SerializeField] private float musicVolume = 1;
	[SerializeField] private float FXVolume = 1;
	private Slider musicSlider;
	private Slider FXSlider;
	// Start is called before the first frame update
	private void OnLevelWasLoaded(int level)
	{
		if (FindObjectOfType<Slider>())
		{
			musicSlider = GameObject.FindGameObjectWithTag("MusicSlider").GetComponent<Slider>();
			FXSlider = GameObject.FindGameObjectWithTag("FXSlider").GetComponent<Slider>();
			musicSlider.value = musicVolume;
			FXSlider.value = FXVolume;
		}
	}
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
