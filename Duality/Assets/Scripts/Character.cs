using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    enum DirectionState
    {
        Left,
        Right
    }

    enum MoveState
    {
        Jump,
        Walk,
        Stand
    }

    // Speed params
    [SerializeField] public float verticalSpeed = 50;
    [SerializeField] public float jumpForce = 100;

    private MoveState _moveState = MoveState.Stand;
    private DirectionState _directionState = DirectionState.Right;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private float _walkTime = 0;
    private float _walkCooldown = 0.2f;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _directionState = _transform.localScale.x > 0 ? DirectionState.Right : DirectionState.Left;
    }

    private void FixedUpdate ()
    {
        if (_moveState == MoveState.Jump)
        {
            if (_rigidbody.velocity == Vector2.zero)
                Stand();
        }
        else if (_moveState == MoveState.Walk)
        {
            _rigidbody.position += (
                (_directionState == DirectionState.Right ? Vector2.right : Vector2.left)
                * verticalSpeed);
            _walkTime -= Time.deltaTime;

            //_rigidbody.velocity = (
            //    (_directionState == DirectionState.Right ? Vector2.right : Vector2.left)
            //    * verticalSpeed * Time.deltaTime);
            //_walkTime -= Time.deltaTime;

            if (_walkTime <= 0)
                Stand();
        }
    }

    public void MoveLeft()
    {
        if (_moveState == MoveState.Jump)
            return;

        _moveState = MoveState.Walk;
        if (_directionState == DirectionState.Right)
        {
            _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
            _directionState = DirectionState.Left;
        }
        _walkTime = _walkCooldown;
    }

    public void MoveRight()
    {
        if (_moveState == MoveState.Jump)
            return;
            
        _moveState = MoveState.Walk;     
        if (_directionState == DirectionState.Left)     
        {
            _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
            _directionState = DirectionState.Right;
        }
        _walkTime = _walkCooldown;
    }

    public void Jump()
    {
        if (_moveState == MoveState.Jump)
            return;

        _rigidbody.AddForce(Vector3.up * jumpForce);
        //_rigidbody.velocity = (Vector3.up * jumpForce /** Time.deltaTime*/);
        _moveState = MoveState.Jump;
    }

    public void Stand()
    {
        _moveState = MoveState.Stand;
    }
}
