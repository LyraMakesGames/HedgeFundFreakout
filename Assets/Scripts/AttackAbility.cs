using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAbility : MonoBehaviour
{
  public Animator animator;    
  public Transform attackPoint;
  public LayerMask attackLayers;
  public Collider2D cameraCollider;
  public Collider2D playerCollider;
  AudioSource cameraCrash;
  public AudioClip cameras;

  //SoundSystem audioManager;

  // Start is called before the first frame update
  void Start()
  {
    cameraCrash = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetButtonDown("Attack"))
    {
      Attack();
    }
  }

  private void Attack()
  {
    animator.SetTrigger("Attacking");
    animator.SetBool("isJumping", false);
  }

  public void OnTriggerStay2D(Collider2D collision) 
  {
    if(collision.gameObject.CompareTag("megatron") && Input.GetButtonDown("Attack"))
    {
      animator.SetTrigger("Attacking");
	    animator.SetBool("isJumping", false);

      cameraCrash.PlayOneShot(cameras, 0.7f);
	    
	    Destroy(collision.gameObject);
    }
  } 
}
