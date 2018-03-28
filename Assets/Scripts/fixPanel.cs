using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class fixPanel : MonoBehaviour {

    
    public GameObject refreshButton;
    public GameObject cameraButton;
    private string s = "";
    private bool flashEnabled = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(DefaultTrackableEventHandler.trackingFound == true)
        {
            cameraButton.SetActive(false);
        }


	}


    public void OnClickRefresh()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

    public void ToggleFlash()
    {
        flashEnabled = !flashEnabled;
        CameraDevice.Instance.SetFlashTorchMode(flashEnabled);
    }
}
