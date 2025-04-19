using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicToScene : MonoBehaviour
{
    [SerializeField] private string sceneNameToLoad;
    [SerializeField] private GameObject previous;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && previous == null)
    	{
       		SceneManager.LoadScene(sceneNameToLoad);
    	}
    }
}
