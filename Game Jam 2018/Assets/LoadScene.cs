using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void loadMainLevel()
	{
		SceneManager.LoadScene ("level1");
	}

	public void loadInstructions ()
	{
		SceneManager.LoadScene ("Instructions");
	}

	public void returnToMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void quit()
	{
		Application.Quit ();
	}
}
