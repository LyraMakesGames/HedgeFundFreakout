using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAbility : MonoBehaviour
{
    //public Animator aniMator;
    public Collider2D doorCollider;
    public Collider2D playerCollider;
    public GameObject cams;
    AudioSource doorSound;
    public AudioClip doors;

    //SoundSystem audioManager;

    // Start is called before the first frame update
    void Start()
    {
        doorSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerStay2D(Collider2D collision) 
    {
       cams = GameObject.FindWithTag("megatron");

       if(cams == null)
        {
            doorSound.PlayOneShot(doors, 0.7f);
        }

       
       if(collision.gameObject.CompareTag("RWBY") && cams == null)
	   {

	       //cams = GameObject.FindWithTag("megatron");

	       Destroy(collision.gameObject);
	   }
    }
}
