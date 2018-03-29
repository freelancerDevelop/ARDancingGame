using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawningController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Spawning();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawning()
    {
        InvokeRepeating("spawn", 2.5f, 2.5f);
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

}
