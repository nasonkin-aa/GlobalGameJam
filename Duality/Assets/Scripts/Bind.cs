using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bind : MonoBehaviour
{
    [SerializeField] private Transform _character;
    [SerializeField] private Transform _gun;
    void Update()
    {
        _gun.position = _character.position; 

    }
}
