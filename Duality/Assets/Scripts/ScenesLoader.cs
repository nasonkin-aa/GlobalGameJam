using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    [SerializeField] int _nextSceneNumber = 0;
    [SerializeField] Transform _character;

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, _character.transform.position);
        if (distance <= 5)
            SceneManager.LoadScene(_nextSceneNumber);

    }
}
