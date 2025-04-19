using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAbility : MonoBehaviour
{
    public float speed = 2;
    public float jumpHeight = 1;

    public bool isGrounded;
    public bool canDoubleJump;

    public Animator animManager;
    public Rigidbody2D rb;

    public AudioSource jumpSound;


    private void Start()
    {
        // This grabs components on the scripted object on load in
        rb = GetComponent<Rigidbody2D>();
        animManager = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        // This is a raycast version of the ground check
        // If you want this to work, UnComment it and Comment all times where isGrounded set to true or false

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));

        // ############ Movement ############

        Vector2 motion = new Vector2(Input.GetAxisRaw("Horizontal"), 0); // float -1 to 1

        transform.Translate(motion * speed * Time.deltaTime);


        // ############ Jumping ############

        if (isGrounded && Input.GetKeyDown(KeyCode.Space) || !isGrounded && canDoubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            animManager.SetBool("isJumping", true);

            jumpSound.Play();

            rb.velocity = Vector2.zero; // stop falling and apply jumpforce
            rb.AddForce(Vector2.up * jumpHeight * 500);

            //audioManager.PlaySFX();
	    
	    if (isGrounded) isGrounded = false;
            else // Only use double jump if not grounded
            {
                canDoubleJump = false;
                //Debug.Log("not grounded");
            }

	    //audio.PlayOneShot(jumpSound, 0.8f);
        }
	else
	{
	    animManager.SetBool("isJumping", false);
	}

        // ############ Animation ############

        if (motion.x != 0) // Moving
        {
            animManager.SetBool("isWalking", true);
        }
        else // Not Moving
        {
            animManager.SetBool("isWalking", false);
        }

        // ############ Flipping Direction ############

        if(motion.x > 0) // Moving Right ->
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (motion.x < 0) // <- Moving Left 
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            //isGrounded = true;
            canDoubleJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            //isGrounded = false;
        }
    }

}
