using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMoveControler : MonoBehaviour
{
    Vector2 jumpDirection = new Vector2(0, 8);
    Vector2 moveAcceleration = new Vector2 (0.9f , 0);
    Vector2 moveSpeed = new Vector2(0.6f, 0);

    List<Collider2D> GroundColliders = new List<Collider2D>();
    bool IsGrounded = true;
    void OnCollisionStay2D()
    {
        IsGrounded = true;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) && IsGrounded)
        {
            GetComponent<Rigidbody2D>().position += moveSpeed;
            GetComponent<Rigidbody2D>().velocity += moveAcceleration;
        }


        if (Input.GetKey(KeyCode.A) && IsGrounded)
        {
            GetComponent<Rigidbody2D>().position -= moveSpeed;
            GetComponent<Rigidbody2D>().velocity -= moveAcceleration;
        }


        if (Input.GetKey(KeyCode.W) && IsGrounded)
        {
            IsGrounded = false;
            GetComponent<Rigidbody2D>().velocity += jumpDirection;
        }
    }
}
