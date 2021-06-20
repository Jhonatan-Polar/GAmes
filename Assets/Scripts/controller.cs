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

    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        manageMovement();
        manageJump();
    }

    private void FixedUpdate()
    {


    }

    void manageMovement()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        if (move != Vector3.zero)
        {
            animator.SetFloat("ejeX", move.x);
            animator.SetFloat("ejeY", move.y);
            //animator.SetBool("running", true);
        }
        else
        {
            if (move.x < 0f) {
                body.AddForce(Vector2.left*speed);
            }
            else if (move.x > 0f)
            {
                body.AddForce(Vector2.right * speed);
            }
            //animator.SetBool("running", false);
        }
        
      
    }

    void manageJump()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            body.AddForce(Vector2.up * jumpspeed);
            //animator.SetFloat("ejeY", move.y);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "suelo")
        {
            inground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "suelo")
        {
            inground = false;
        }
    }
}