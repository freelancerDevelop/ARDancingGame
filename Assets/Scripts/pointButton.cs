using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointButton : MonoBehaviour {

    private int buttonPoints = 500;
    private int[] points = { 500, 750, 1000, 1250, 2500, 5000 };
    private Text buttonText;
    private float speed = 7f;
    private Image buttonColor;

    private float timer = 0f;
	// Use this for initialization
	void Start () {
        buttonPoints = points[Random.Range(0, 5)];
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = buttonPoints.ToString();
        speed = Random.Range(7f, 13f);
        buttonColor = GetComponent<Image>();
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        buttonColor.color = newColor;
	}
	
	// Update is called once per frame
	void Update () {
            transform.Translate(-speed, 0, 0);
	}
}
