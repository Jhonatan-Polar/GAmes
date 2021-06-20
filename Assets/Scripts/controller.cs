using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    Vector3 move, jump;
    public float speed, jumpspeed;
    public Rigidbody2D body;
    public Animator animator;
    
    public bool inground;
    public int jumps;

    // Start is called before the first frame update
    void Start()
    {
        
        body = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        //SoundSystemScript.PlaySoundtrack("music");
    }

    private void FixedUpdate()
    {
        manageMovement();
        manageJump();
    }

    void manageMovement()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        if (move != Vector3.zero)
        {
            animator.SetFloat("ejeX", move.x);
            animator.SetFloat("ejeY", move.y);
            animator.SetBool("running", true);
        }
        else
        {
            animator.SetBool("running", false);
        }

        if (move.x < 0f)
        {
            body.AddForce(Vector3.left * speed);
        }
        else if (move.x > 0f)
        {
            body.AddForce(Vector3.right * speed);
        }
    }

    void manageJump()
    {
        if (Input.GetKey(KeyCode.Space) && (inground == true || jumps > 0))
        {
            body.AddForce(Vector2.up * jumpspeed);
            animator.SetBool("jumping", true);
            jumps -= 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("suelo"))
        {
            animator.SetBool("jumping", false);
            inground = true;
            jumps = 2;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("suelo"))
        {
            inground = false;
        }
    }
}