using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wifi : MonoBehaviour
{
    public GameObject wifiPrefab;
    bool Chek = true;

    private void OnMouseDown()
    {
        wifiPrefab.SetActive(true);
    }
    private void OnMouseUp()
    {
        wifiPrefab.SetActive(false);
    }

    private void Update()
    {
        SwapType();
    }
    private void Start()
    {
        wifiPrefab.GetComponent<SpriteRenderer>().color = Color.red;
    }
    private void SwapType()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (Chek)
            {
                wifiPrefab.GetComponent<SpriteRenderer>().color = Color.red;
                Chek = false;
            }
            else
            {
                wifiPrefab.GetComponent<SpriteRenderer>().color = Color.gray;
                Chek = true;
            }
                
            }
        }
    }


