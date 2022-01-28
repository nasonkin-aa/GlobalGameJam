using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMoveControler : MonoBehaviour
{

    Vector2 moveDirection = new Vector2 (0.5f , 0);

    List<Collider2D> GroundColliders = new List<Collider2D>();
    bool IsGrounded = true;
    void OnCollisionStay2D()
    {
        IsGrounded = true;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) && IsGrounded)
            GetComponent<Rigidbody2D>().velocity += moveDirection;

        if (Input.GetKey(KeyCode.A) && IsGrounded)
            GetComponent<Rigidbody2D>().velocity -= moveDirection;

        if (Input.GetKey(KeyCode.W) && IsGrounded)
        {
            IsGrounded = false;
            GetComponent<Rigidbody2D>().velocity += new Vector2(0, 3);
        }
    }
}
