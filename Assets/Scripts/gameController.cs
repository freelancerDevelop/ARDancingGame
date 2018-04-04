using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {

    public GameObject HSPanel;
    private Animator anim;
    public Text highscoreText;
    public AudioClip clip;
    public AudioSource audio;
    public GameObject flashButton;
    public Text timeText;
    public CanvasGroup endGameFadeout;

    private float theTimeLeft = 60f;
    public bool gameFinished = false;

    public static gameController instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
       anim = HSPanel.GetComponent<Animator>();
       GetHighscore();
       audio = GetComponent<AudioSource>();
       theTimeLeft = clip.length; 
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "main")
        {
            {

            }
            if (spawningController.instance.isGamePlaying == true)
            {

                theTimeLeft -= Time.deltaTime;
                //timeText.text = "Time: " + theTimeLeft.ToString("f0");
                int minutes = Mathf.FloorToInt(theTimeLeft / 60f);
                int seconds = Mathf.FloorToInt(theTimeLeft - minutes * 60);
                timeText.text = string.Format("Time: {0:0}:{1:00}", minutes, seconds);
                flashButton.SetActive(false);
            }
            else if (spawningController.instance.isGamePlaying == false)
            {
                flashButton.SetActive(true);
            }

            if (theTimeLeft <= 0f)
            {
                GameOver();
            }
        }
        
	}


    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void BackToIntro()
    {
        SceneManager.LoadScene("loadingScreen");
    }

    public void PlayMusic()
    {
        audio.Play();
    }

    public void StopMusic()
    {
        audio.Stop();
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
        if (PlayerPrefs.HasKey("Highscore") == false || PlayerPrefs.GetString("Highscore") == "")
        {
            PlayerPrefs.SetString("Highscore", "0");
        }
        highscoreText.text = PlayerPrefs.GetString("Highscore");
    }

    public void GameOver()
    {
        StartCoroutine(EndGameScreen());
        gameFinished = true;
        timeText.text = "Time : 0";
        StopMusic();
        spawningController.instance.CancelInvoke();
        OnClickHighscore();
        highscoreText.text = spawningController.instance.myScore.text.ToString();
        spawningController.instance.DestroyChildrenButtons();
        int oldHighscore = int.Parse(PlayerPrefs.GetString("Highscore"));
        int newHighscore = int.Parse(highscoreText.text);

        if(oldHighscore < newHighscore)
        {
            PlayerPrefs.SetString("Highscore", newHighscore.ToString());
        }
    }

    IEnumerator EndGameScreen()
    {
        do
        {
            endGameFadeout.alpha += Time.deltaTime;
            yield return null;
        } while (endGameFadeout.alpha <= 1);
    }

}
