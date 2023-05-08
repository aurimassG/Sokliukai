using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public Animator animator;
    AudioSource jumpsound;
    AudioSource fallofmapsound;
    private float speed = 8f;
    private float jumpingPower = 20f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public LogicScript logic;
    public GameObject Score;
    public GameObject FScore;
    public Text TeamCredits;

    private bool doublejump;

    private bool levelcomplete = false;


    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;
        jumpsound = GetComponent<AudioSource>();
        fallofmapsound = GetComponent<AudioSource>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        logic.StartingScore();
    }

    // Update is called once per frame
    public void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        if(IsGrounded() && !Input.GetButton("Jump"))
        {
            doublejump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded() || doublejump)
            {
                jumpsound.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                doublejump = !doublejump;
            }
        }
        if (Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
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
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
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

        

        if (collision.tag == "Finish" && !levelcomplete)
        {
            logic.computeScore();
            logic.Stop();
            logic.SetEndText();
            levelcomplete = true;
            Invoke("LygisBaigtas", 3f);

        }
        if(collision.tag == "Finish" && levelcomplete == false)  // cia trash kodas biski, bet veikia taip padarius, jeigu ateity bus bugu tai pakeisim
        {
            SceneManager.LoadScene("EndScreen");
        }

    }

    private void LygisBaigtas()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
