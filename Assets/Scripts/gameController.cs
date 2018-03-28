using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {

    public GameObject HSPanel;
    private Animator anim;

    // Use this for initialization
    void Start () {
       anim = HSPanel.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void StartGame()
    {
        SceneManager.LoadScene("UDT_Sample");
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

}
