using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointButton : MonoBehaviour {

    private int buttonPoints = 500;
    private int[] points = { 500, 750, 1000, 1250, 2500, 5000 };


    private float speed = 7f;
    private string[] moves = {"house_dance", "bboy_dance", "gangnam_dance" };

    private Text buttonText;
    private Image buttonColor;
    
	// Use this for initialization
	void Start () {
        buttonPoints = points[Random.Range(0, 5)];
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = buttonPoints.ToString();
        speed = Random.Range(12f, 16f);


        buttonColor = GetComponent<Image>();
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        buttonColor.color = newColor;


        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(onTaskClicked);
	}
	
	// Update is called once per frame
	void Update () {
            transform.Translate(-speed, 0, 0);
	}

    void onTaskClicked()
    {
        spawningController.instance.MakeMove(moves[Random.Range(0, 3)]);
        spawningController.instance.addScore(buttonPoints);
    }
}
