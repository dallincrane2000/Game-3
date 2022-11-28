using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Rigidbody2D rb;
    public GameObject portal;
    public Animator animator;
    public AudioSource crateAudio;

    [SerializeField] float startDashTime = .25f;
    [SerializeField] float dashSpeed = 15f;
 
    //Rigidbody2D rb;
 
    float currentDashTime;
 
    bool canDash = true;
    bool playerCollision = true;
    bool canMove = true;

    Vector2 movement;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKey(KeyCode.W) && canDash && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Inside");
            StartCoroutine(Dash(Vector2.up));
        }
        if (Input.GetKey(KeyCode.A) && canDash && Input.GetKeyDown(KeyCode.Space))
        {
             StartCoroutine(Dash(Vector2.left));
        }
        if (Input.GetKey(KeyCode.S) && canDash && Input.GetKeyDown(KeyCode.Space))
        {
             StartCoroutine(Dash(Vector2.down));
        }
        if (Input.GetKey(KeyCode.D) && canDash && Input.GetKeyDown(KeyCode.Space))
        {
             StartCoroutine(Dash(Vector2.right));
        }

    }

    IEnumerator Dash(Vector2 direction)
        {
            canDash = false;
            canMove = false;
            playerCollision = false;
            currentDashTime = startDashTime; // Reset the dash timer.
    
            while (currentDashTime > 0f)
            {
                currentDashTime -= Time.deltaTime; // Lower the dash timer each frame.
    
                rb.velocity = direction * dashSpeed; // Dash in the direction that was held down.
                // No need to multiply by Time.DeltaTime here, physics are already consistent across different FPS.
    
                yield return null; // Returns out of the coroutine this frame so we don't hit an infinite loop.
            }
    
            rb.velocity = new Vector2(0f, 0f); // Stop dashing.
    
            canDash = true;
            canMove = true;
            playerCollision = true;
        }

    void FixedUpdate()
    {
        if(canMove == true)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PushObject")
        {
            crateAudio.Play();
        }

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PushObject")
        {
            crateAudio.Stop();
        }
    }
}