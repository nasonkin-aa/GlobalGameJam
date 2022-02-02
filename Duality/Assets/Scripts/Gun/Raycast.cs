using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] float speed = 0f;
    [SerializeField] private LayerMask _layerMask;

    public Rigidbody2D rb;

    Polarity.PolarityType playerType = Polarity.PolarityType.south;

    private void Start()
    {
        _character.GetComponent<SpriteRenderer>().color = Color.cyan;

    }
    private void FixedUpdate()
    {
        RayCastGun();
    }
    private void Update()
    {
        SwapType();
    }
    private void SwapType()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerType == Polarity.PolarityType.south)
            {
                playerType = Polarity.PolarityType.north;
                _character.GetComponent<SpriteRenderer>().color = Color.red;

            }
            else if (playerType == Polarity.PolarityType.north)
            {
                _character.GetComponent<SpriteRenderer>().color = Color.cyan;

                playerType = Polarity.PolarityType.south;
            }
        }
    }

    private void PushOrPull(Transform _transform, Vector2 direction, float speed)
    {
        if (direction.magnitude <= 0.1)
        {
            return;
        }

        _transform.transform.GetComponent<Rigidbody2D>().AddForce((1 / direction.magnitude * direction.normalized) * speed);
        Debug.Log(direction);
    }
    private void RayCastGun()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit2D _hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 100, _layerMask);

            var direction = new Vector2(
                _character.transform.position.x - _hit.point.x,
                _character.transform.position.y - _hit.point.y);

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * 100f, Color.red);
            if (_hit)
            {
                if (_hit.transform.GetComponent<Polarity>() && _hit.transform.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static)
                {
                    if (_hit.transform.GetComponent<Polarity>().polarityType == playerType)
                    {
                        PushOrPull(_character.transform, direction, speed);
                    }
                    else
                    {
                        PushOrPull(_character.transform, -direction, speed);
                    }
                }

                if (_hit.transform.GetComponent<Polarity>() && _hit.transform.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
                {
                    if (_hit.transform.GetComponent<Polarity>().polarityType == playerType)
                    {
                        PushOrPull(_hit.transform, -direction, speed);
                    } else

                    //if (_hit.transform.GetComponent<Polarity>().polarityType != playerType)
                    {
                        if (_hit.distance >= 10)
                        {
                            PushOrPull(_hit.transform, direction, speed);
                        } else
                        {
                            _hit.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        }                                           
                    }
                }
            }
        }

    }
}

