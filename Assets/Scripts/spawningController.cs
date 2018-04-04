using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


public class spawningController : DefaultTrackableEventHandler {

    public static spawningController instance;


    public Text myScore;
    private GameObject dancer;
    private Animator anim;
    public GameObject Instructions;


    public bool isGamePlaying = false;
    private bool hasSpawningStarted = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(hasSpawningStarted == false && DefaultTrackableEventHandler.trackingFound == true)
        {
            hasSpawningStarted = true;
            Spawning();
            if (gameController.instance.audio.isPlaying == false)
            {
                gameController.instance.PlayMusic();
            }
        }
        else if(hasSpawningStarted == true && DefaultTrackableEventHandler.trackingFound == false)
        {
            hasSpawningStarted = false;
            isGamePlaying = false;
            CancelInvoke();
        }
	}


    public void StartGame()
    {
        Instructions.SetActive(false);
    }

    public void Spawning()
    {
        InvokeRepeating("spawn", 2.5f, 2.5f);
        isGamePlaying = true;
    }
    
    private void spawn()
    {
        GameObject spawnedButton = (GameObject)Instantiate(Resources.Load("Point Button"));
        //spawnedButton.transform.parent = transform;
        spawnedButton.transform.SetParent(gameObject.transform, false);

        RectTransform position = spawnedButton.GetComponent<RectTransform>();
        position.localPosition = new Vector3(0, 10, 0);
        position.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }

    public void addScore(int theScore)
    {
        myScore.text = (int.Parse(myScore.text) + theScore).ToString();
        DestroyChildrenButtons();
    }


    public void DestroyChildrenButtons()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void MakeMove(string danceMove)
    {
        dancer = GameObject.Find("UserDefinedTarget-1/SportyGranny");
        anim = dancer.GetComponent<Animator>();
        anim.SetTrigger(danceMove);
    }

}
