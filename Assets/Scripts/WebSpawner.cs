using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpawner : MonoBehaviour
{
    [SerializeField] private Vector2[] webLocations;
    [SerializeField] private GameObject web;
    void Start()
    {   //spawns webs
        for (int i = webLocations.Length -1 ; i > 0; i--) 
        {
            Instantiate(web, webLocations[i], Quaternion.identity);
        }
    }
}
