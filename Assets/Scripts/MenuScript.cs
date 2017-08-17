using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

// public Canvas helpMenu; 
public GameObject quitPanel;

public Button startText;
public Button helpText;
public Button exitText;

public string helpLevel;
public string startLevel;

/// loading
	AsyncOperation ao;
//	public GameObject loadingScreenBG;
//	public Slider progressBar;
	public Image progressRadial;
	public Text loadingText;

	public bool isFakeLoadingBar = false;
//	public float fakeIncrement = 0f;
//	public float fakeTiming = 0f;




void Start()
	{
        if(quitPanel)
        quitPanel.SetActive(false);

        if(startText)
        startText = startText.GetComponent<Button>();
        if(helpText)
		helpText = helpText.GetComponent<Button>();
        if(exitText)
        exitText = exitText.GetComponent<Button>();

//		progressBar.gameObject.SetActive (false);
if(progressRadial)
		progressRadial.gameObject.SetActive (false);
	}

	/// <Language Selction>

	public void FAn_MainMenuPressed()
	{
		SceneManager.LoadScene ("FAn_MainMenu");
	}
	public void FA_MainMenuPressed()
	{
		SceneManager.LoadScene ("FA_MainMenu");
	}
	public void EN_MainMenuPressed()
	{
		SceneManager.LoadScene ("EN_MainMenu");
	}

	/// <Help Level>

	public void HelpPress() 
	{
	//	Application.LoadLevel (1);

		SceneManager.LoadScene (helpLevel);
	}

   ////////////


public void StartLevel()
	{
		startText.enabled = false;
		helpText.enabled = false;
		exitText.enabled = false;

//		SceneManager.LoadScene (startLevel);

//		loadingScreenBG.SetActive(true);
//		progressBar.gameObject.SetActive (true);
		progressRadial.gameObject.SetActive (true);
		loadingText.gameObject.SetActive (true);
		loadingText.text = "loading ...";

		if (!isFakeLoadingBar) 
		{
			StartCoroutine (LoadingLevelWithRealProgress());	
		} 
		else 
		{
			
		}

	}


	IEnumerator LoadingLevelWithRealProgress()
	{
		yield return new WaitForSeconds (1);

		ao = SceneManager.LoadSceneAsync (startLevel);
//		ao.allowSceneActivation = false;

		while (!ao.isDone) 
		{
//			progressBar.value = ao.progress;
			progressRadial.fillAmount = ao.progress;

//			if(ao.progress == 0.9f)
//			{
//				progressBar.value = 1f;
//				loadingText.text = "Press 'F' To Continue";
//				if (Input.GetKeyDown(KeyCode.F))
//				{
//					ao.allowSceneActivation = true;
//				}
//			}
			Debug.Log (ao.progress);
			yield return null;
		}
	}


public void ExitPress() 
	{
        quitPanel.SetActive(true);
        //quitPanel.enabled = true;

        startText.enabled = false;
	    helpText.enabled = false;
	    exitText.enabled = false;
	}


public void BackPress() 
	{
        quitPanel.SetActive(false);
        //quitPanel.enabled = false;

        startText.enabled = true;
	    helpText.enabled = true;
	    exitText.enabled = true;
	}


public void ExitGame() 
    {
        Application.Quit();
    }
}