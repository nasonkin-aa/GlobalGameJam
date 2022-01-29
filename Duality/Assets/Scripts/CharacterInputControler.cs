using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterInputControler : MonoBehaviour
{
    private Character Character;

    private void Start()
    {
        Character = Character == null ? GetComponent<Character>() : Character;
        if (Character == null)
            Debug.Log("Character not set");
    }

    private void Update()
    {
        if (Character)
        {
            if (Input.GetKey(KeyCode.A))
                Character.MoveLeft();
            if (Input.GetKey(KeyCode.D))
                Character.MoveRight();
            if (Input.GetKey(KeyCode.W))
                Character.Jump();
        }
    }
    // TO DO //
    // Переделать прыжок

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    //Vector2 jumpDirection = new Vector2(0, 4);
    //Vector2 moveAcceleration = new Vector2 (0.3f , 0);
    //Vector2 moveSpeed = new Vector2(0.2f, 0);

    //List<Collider2D> GroundColliders = new List<Collider2D>();
    //bool IsGrounded = true;
    //void OnCollisionStay2D()
    //{

    //    IsGrounded = true;
    //}

    //private void FixedUpdate()
    //{
    //    if (Input.GetKey(KeyCode.D) && IsGrounded)
    //    {
    //        GetComponent<Rigidbody2D>().position += moveSpeed;
    //        GetComponent<Rigidbody2D>().velocity += moveAcceleration;
    //    }


    //    if (Input.GetKey(KeyCode.A) && IsGrounded)
    //    {
    //        GetComponent<Rigidbody2D>().position -= moveSpeed;
    //        GetComponent<Rigidbody2D>().velocity -= moveAcceleration;
    //    }


    //    if (Input.GetKey(KeyCode.W) && IsGrounded)
    //    {
    //        IsGrounded = false;
    //        GetComponent<Rigidbody2D>().velocity += jumpDirection;
    //    }
    //}
}
