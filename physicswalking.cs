using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicswalking : MonoBehaviour
{
    public float MoveSpeed, JumpForce;

    public bool Jumping;

    public Rigidbody2D RG2D;

    // Start is called before the first frame update
    void Start()
    {
        RG2D = GetComponent<Rigidbody2D>();

        MoveSpeed = 15f;
        JumpForce = 20f;

        Jumping = true;
    }

    // Update is called once per frame
    void Update()
    {
        float MovX = Input.GetAxisRaw("Horizontal");
        float MovY = Input.GetAxisRaw("Vertical");

        // Horizontal Movement
        if (MovX != 0)
        {
            RG2D.velocity = new Vector2(MoveSpeed * MovX, RG2D.velocity.y);
        }

        // Jumping
        if (MovY == 1 && !Jumping)
        {
            RG2D.velocity = new Vector2(RG2D.velocity.x, JumpForce);
            
        }

        // Crouching
        if (MovY == -1)
        {
            transform.localScale = new Vector2(1f, 0.5f);
        }

        else
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
     
    {

        Jumping = false;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        Jumping = true;
    }

}
