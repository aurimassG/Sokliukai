using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public Animator animator;
    AudioSource jumpsound;
    private float speed = 8f;
    private float jumpingPower = 20f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public LogicScript logic;

    // Start is called before the first frame update
   private void Start()
    {
        jumpsound = GetComponent<AudioSource>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
   private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpsound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if(Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            jumpsound.Play();
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Moneta") 
        {
            logic.addScore();
            collision.gameObject.SetActive(false);
        }
    }

}
