using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingAbility : MonoBehaviour
{
    [SerializeField] private string sceneNameToLoad;
    public GameObject cams;
    //public AudioSource doorSound;
    
    // Start is called before the first frame update
    private void Start()
    {
        //doorSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        cams = GameObject.FindWithTag("megatron");

   //      if(cams == null)
   //      {
			// doorSound.Play(); 
   //      }

        if(collision.gameObject.CompareTag("Player") && cams == null)
        {
            //doorSound.Play();

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
