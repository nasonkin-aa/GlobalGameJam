using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetGun : MonoBehaviour
{
    [SerializeField] private Transform _magnetGun;
    private Vector2 _derection;

    void Update()
    {
        Vector2 _mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _derection = _mousPos - (Vector2)_magnetGun.position;
        _magnetGun.transform.up = _derection;

    }

    
}
