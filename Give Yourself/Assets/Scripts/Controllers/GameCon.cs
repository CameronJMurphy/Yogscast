using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCon : MonoBehaviour
{
	public static GameCon instance;
	//[SerializeField] private int lastSceneIndex;
	private string lastScene;

	// Start is called before the first frame update
	void Start()
    {
		if (instance == null) //singleton
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(this);
		UICon.startGame += StartGame;
		UICon.backButton += BackButtonPress;
		UICon.optionsButton += OptionsButtonPress;
		UICon.quitButton += QuitButtonPress;
		UICon.resetButton += ResetButtonPress;
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
		SceneManager.LoadScene(lastScene);
	}

	private void OptionsButtonPress()
	{
		lastScene = SceneManager.GetActiveScene().name;
		
		SceneManager.LoadScene("Options");
	}

	private void QuitButtonPress()
	{
		Debug.Log("Quit");
		Application.Quit();
	}

	private void ResetButtonPress()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
