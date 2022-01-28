using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private GameObject _character;

    private Polarity _redObjects;
    private void FixedUpdate()
    {
        RayCastGun();
    }

    private void RayCastGun()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 100f, Color.red);

            RaycastHit2D _hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up));


            if (_hit)
            {
                if (_hit.transform.GetComponent<Polarity>() && _hit.transform.GetComponent<Polarity>().polarityType == Polarity.PolarityType.north )
                {
                    float _ganRotation = (transform.rotation.eulerAngles.z + 90f) * (Mathf.PI / 180);
                    Vector2 _rayCastVector = new Vector2(Mathf.Cos(_ganRotation), Mathf.Sin(_ganRotation));

                    _hit.transform.GetComponent<Rigidbody2D>().velocity += _rayCastVector * 5;
                }
                if (_hit.transform.GetComponent<Polarity>() && _hit.transform.GetComponent<Polarity>().polarityType == Polarity.PolarityType.south)
                {

                    _hit.transform.position = Vector3.MoveTowards(_hit.transform.position, transform.position , Time.deltaTime * 11);
                }
            }
        }
    }
}

