using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] float speed = 5f;

    Polarity.PolarityType playerType = Polarity.PolarityType.south;
    private void FixedUpdate()
    {
        RayCastGun();
        SwapType();
    }

    private void SwapType()
    {
        if (Input.GetKeyDown(KeyCode.Z)){
            Debug.Log("Z нажата");

            //GetKey(KeyCode.Z)){
            if (playerType == Polarity.PolarityType.south){
                playerType = Polarity.PolarityType.north;
            } else 
            if (playerType == Polarity.PolarityType.north){
                playerType = Polarity.PolarityType.south;
            }
        }
    }

    private void AddObjectVelocity (Transform transform, float rectangle)
    {
        float _ganRotation = (transform.rotation.eulerAngles.z + rectangle) * (Mathf.PI / 180);
        Vector2 _rayCastVector = new Vector2(Mathf.Cos(_ganRotation), Mathf.Sin(_ganRotation));

        transform.GetComponent<Rigidbody2D>().velocity += _rayCastVector * speed;
    }

    private void RayCastGun()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 100f, Color.red);
            RaycastHit2D _hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up));

            if (_hit)
            {
                if (_hit.transform.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static)
                {
                    if (_hit.transform.GetComponent<Polarity>() && _hit.transform.GetComponent<Polarity>().polarityType == playerType)
                    {
                        //float _ganRotation = (transform.rotation.eulerAngles.z - 90f) * (Mathf.PI / 180);
                        //Vector2 _rayCastVector = new Vector2(Mathf.Cos(_ganRotation), Mathf.Sin(_ganRotation));

                        //transform.GetComponent<Rigidbody2D>().velocity += _rayCastVector * 5;
                        AddObjectVelocity(transform, -90f);
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, _hit.point, Time.deltaTime * speed * 2);
                    }

                }
                else
                {
                    if (_hit.transform.GetComponent<Polarity>() && _hit.transform.GetComponent<Polarity>().polarityType == playerType)
                    {
                        AddObjectVelocity(_hit.transform, 90f);
                        //float _ganRotation = (transform.rotation.eulerAngles.z + 90f) * (Mathf.PI / 180);
                        //Vector2 _rayCastVector = new Vector2(Mathf.Cos(_ganRotation), Mathf.Sin(_ganRotation));

                        //_hit.transform.GetComponent<Rigidbody2D>().velocity += _rayCastVector * 5;
                    }

                    if (_hit.transform.GetComponent<Polarity>() && _hit.transform.GetComponent<Polarity>().polarityType != playerType)
                    {
                        _hit.transform.position = Vector2.MoveTowards(_hit.transform.position, transform.position, Time.deltaTime * speed * 2);
                            Vector3.MoveTowards(_hit.transform.position, transform.position, Time.deltaTime * speed * 2);
                    }
                }
            }
        }

    }
}

