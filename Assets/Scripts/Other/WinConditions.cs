using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class WinConditions : MonoBehaviour
{
    private GameObject[] Webs;
    private Enemy[] Allenemies;
    private Player[] AllPlayers;
    private AudioSource audioSource;
    [SerializeField] TextMeshProUGUI GameOverText; 

    private void Update()
    {
        Webs = GameObject.FindGameObjectsWithTag("Web");
        Allenemies = FindObjectsOfType<Enemy>();
        AllPlayers = FindObjectsOfType<Player>();
        audioSource = FindObjectOfType<AudioSource>();


        print(Webs.Length);
        if (Webs.Length == 0)
        {
            for (int i = 0; i < Allenemies.Length; i++)
            {
                Allenemies[i].enabled = (false);
            }
            for (int i = 0;i < AllPlayers.Length; i++)
            {
                AllPlayers[i].enabled = false;
            }
            audioSource.enabled = false;
            if 
            GameOverText.text =   "Wins!";

        }
    }
}
