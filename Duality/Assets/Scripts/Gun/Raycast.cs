using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] float speed = 5f;
    [SerializeField] private LayerMask _layerMask;


    public Rigidbody2D rb;

    Polarity.PolarityType playerType = Polarity.PolarityType.south;
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
            Debug.Log("Z нажата");
            //GetKey(KeyCode.Z)){
            if (playerType == Polarity.PolarityType.south)
            {
                playerType = Polarity.PolarityType.north;
                _character.GetComponent<SpriteRenderer>().color = Color.red;
                Debug.Log(playerType);
            } 
            else if (playerType == Polarity.PolarityType.north)
            {
                playerType = Polarity.PolarityType.south;
                _character.GetComponent<SpriteRenderer>().color = Color.blue;
                Debug.Log(playerType);
            }
        }
    }
    private void AddObjectVelocity (Transform transform, float rectangle)
    {
        float _ganRotation = (transform.rotation.eulerAngles.z + rectangle) * (Mathf.PI / 180);
        Vector2 _rayCastVector = new Vector2(Mathf.Cos(_ganRotation), Mathf.Sin(_ganRotation));

        transform.GetComponent<Rigidbody2D>().velocity += _rayCastVector * speed;
      // Debug.DrawLine(_character.transform.position, _character.transform.GetComponent<Rigidbody2D>().velocity, Color.blue, 10f);
    }
    private void RayCastGun()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit2D _hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up),10,_layerMask);

            var direction = new Vector2(
                (_character.transform.position.x - _hit.point.x),
                _character.transform.position.y - _hit.point.y);

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 10f, Color.red);
            if (_hit)
            {
                if (_hit.transform.GetComponent<Polarity>() && _hit.transform.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static)
                {
                    if ( _hit.transform.GetComponent<Polarity>().polarityType == playerType)
                    {

                        ////float _ganRotation = (_character.transform.rotation.eulerAngles.z + 90f) * (Mathf.PI / 180);
                        ////Vector2 _rayCastVector = new Vector2(Mathf.Cos(_ganRotation), Mathf.Sin(_ganRotation));

                        ////_character.transform.GetComponent<Rigidbody2D>().velocity += _rayCastVector * speed;
                        ////Debug.DrawLine(_character.transform.position, _character.transform.GetComponent<Rigidbody2D>().velocity, Color.blue, 10f);


                        //transform.rotation = Quaternion.RotateTowards(transform.rotation,
                        //Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, direction)), 205 * Time.deltaTime);

                        //float _ganRotation = (_hit.transform.rotation.eulerAngles.z - 90f) * (Mathf.PI / 180);
                        //Vector2 _rayCastVector = new Vector2(Mathf.Cos(_ganRotation), Mathf.Sin(_ganRotation));

                        _character.transform.GetComponent<Rigidbody2D>().AddForce((direction * speed));
                        ////AddObjectVelocity(_character.transform, -90);
                        
                    }
                    else
                    {
                        //.GetComponent<Rigidbody2D>().AddForce(direction * speed);
                        _character.transform.GetComponent<Rigidbody2D>().AddForce((-direction * speed));
                       // _character.transform.position = Vector3.MoveTowards(transform.position, _hit.point, Time.deltaTime * speed * 2);

                    }
                }

                else if(_hit.transform.GetComponent<Polarity>() && _hit.transform.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
                {
                    if ( _hit.transform.GetComponent<Polarity>().polarityType == playerType)
                    {
                        _hit.transform.GetComponent<Rigidbody2D>().AddForce((-direction * speed));
                        //Vector3.MoveTowards(_hit.transform.position, transform.position, Time.deltaTime * speed * 2);  
                    }
                    if (_hit.transform.GetComponent<Polarity>() && _hit.transform.GetComponent<Polarity>().polarityType != playerType)
                    {
                        _hit.transform.GetComponent<Rigidbody2D>().AddForce(direction * speed);
                         //_hit.transform.position = Vector2.MoveTowards(_hit.transform.position, transform.position, Time.deltaTime * speed * 2);
                    }
                }
            }
        }

    }
}

