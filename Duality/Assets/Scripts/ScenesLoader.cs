using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    [SerializeField] int _nextSceneNumber = 0;
    [SerializeField] Transform _character;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("sda");
        if (collision.transform == _character)
        {
            SceneManager.LoadScene(_nextSceneNumber);

        }
    }
}
