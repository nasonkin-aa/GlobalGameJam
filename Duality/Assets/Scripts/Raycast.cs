using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private void Update()
    {
        RayCastGun();
    }
    private void RayCastGun()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 100f, Color.red);

            RaycastHit2D _hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 12);

            if (_hit)
            {
                Debug.Log("hi" + _hit.collider.name);
            }
        }
    }
}
