using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMoveControler : MonoBehaviour
{
    [SerializeField] Vector2 jumpDirection = new Vector2(0, 8);
    [SerializeField] Vector2 moveAcceleration = new Vector2(0.9f, 0);
    [SerializeField] Vector2 moveSpeed = new Vector2(0.6f, 0);
    [SerializeField] Vector2 maxJumpAcceleration = new Vector2(15, 0);
    [SerializeField] LayerMask _layerMask;
    private Vector2 jumpAcceleration = Vector2.zero;
    private bool isGround = true;

    List<Collider2D> GroundColliders = new List<Collider2D>();

    private void FixedUpdate()
    {
        OnGround();

        if (!isGround)
            return;

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().position += moveSpeed;
            if (jumpAcceleration.x <= maxJumpAcceleration.x)
                jumpAcceleration += moveAcceleration;
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().position -= moveSpeed;
            if (jumpAcceleration.x >= - maxJumpAcceleration.x)
                jumpAcceleration -= moveAcceleration;
        }

        //if (Input.GetKey(KeyCode.W))
        //    GetComponent<Rigidbody2D>().velocity +=  jumpAcceleration;

        //if (transform.GetComponent<Rigidbody2D>().velocity.y == 0)
        //    transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        
    }

    private void OnGround()
    {
        //TO DO: Нельзя двигаться на ящиках, переписать эту говну, убрать разгон при прыжках
        RaycastHit2D _hit = Physics2D.Raycast(transform.position + new Vector3 (-4, 0, 0), transform.TransformDirection(Vector2.down),6.5f , _layerMask);
        RaycastHit2D _hit1 = Physics2D.Raycast(transform.position + new Vector3(4, 0, 0), transform.TransformDirection(Vector2.down), 6.5f, _layerMask);
    

        //Debug.Log(_hit);
        Debug.DrawRay(transform.position + new Vector3(-4, 0, 0), transform.TransformDirection(Vector2.down) * 6.5f, Color.green);
        Debug.DrawRay(transform.position + new Vector3(4, 0, 0), transform.TransformDirection(Vector2.down) * 6.5f, Color.green);

        isGround = _hit || _hit1 ? true : false;
    }


}
