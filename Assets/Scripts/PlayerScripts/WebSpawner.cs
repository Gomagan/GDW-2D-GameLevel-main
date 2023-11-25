using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSpawner : MonoBehaviour
{
    [SerializeField] private Vector2[] webLocations;
    [SerializeField] private GameObject web;
    [SerializeField] private GameObject venom;

    public float spawnInterval;
    private float timer = 0f;




    void Start()
    {
        //spawns webs
        for (int i = webLocations.Length -1 ; i > 0; i--) 
        {
            Instantiate(web, webLocations[i], Quaternion.identity);
        }

        VenomSpawn();
    }


    

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            VenomSpawn();
            timer = 0f;
        }
    }

    private void VenomSpawn()
    {
        float randomNumber = Random.Range(0, webLocations.Length - 1);
        int ranNum = (int)randomNumber;
        Instantiate(venom, webLocations[ranNum], Quaternion.identity);
    }
}
