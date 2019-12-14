using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCon : MonoBehaviour
{
	private int lastSceneIndex;

	// Start is called before the first frame update
	void Start()
    {
		UICon.startGame += StartGame;
		UICon.backButton += BackButtonPress;
		UICon.optionsButton += OptionsButtonPress;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ResetLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void NextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	private void StartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	private void BackButtonPress()
	{
		SceneManager.LoadScene(lastSceneIndex);
	}

	private void OptionsButtonPress()
	{
		lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene("Options");
	}
}
