using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    Vector2 move,jump;
    public float speed,jumpspeed;
    public Rigidbody2D body;
    public Animator animator;
    
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
        move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        if (move != Vector2.zero)
        {
            animator.SetFloat("ejeX", move.x);
            //animator.SetBool("running", true);
        }
        else
        {
            //animator.SetBool("running", false);
        }

        body.AddForce(move*speed);
        

    }

    void manageJump()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            body.AddForce(Vector2.up * jumpspeed);
            //animator.SetFloat("ejeY", move.y);
        }
        

    }
}
