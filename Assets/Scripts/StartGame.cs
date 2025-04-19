using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //[SerializeField] private float delayBeforeLoading = 10f;
    [SerializeField] private string sceneNameToLoad;
    //private float timeElapsed;
    //public Animator aniMator;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetKeyDown(KeyCode.Space))
    	{
    		SceneManager.LoadScene(sceneNameToLoad);
    	}
    }
}
