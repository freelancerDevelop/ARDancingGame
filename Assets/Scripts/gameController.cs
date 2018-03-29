using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {

    public GameObject HSPanel;
    private Animator anim;
    public Text highscoreText;
    // Use this for initialization
    void Start () {
       anim = HSPanel.GetComponent<Animator>();
       GetHighscore();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnClickHighscore()
    {
        anim.SetTrigger("playHSAnim");
    }

    public void OnClickBackHighscore()
    {
        anim.SetTrigger("goBack");
    }

    private void GetHighscore()
    {
        highscoreText.text = PlayerPrefs.GetString("Highscore");
    }

    public void GameOver()
    {
        // TODO: Implement XD
    }

}
