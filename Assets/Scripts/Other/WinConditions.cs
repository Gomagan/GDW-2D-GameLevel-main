using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditions : MonoBehaviour
{
    private GameObject[] Webs;
    private Enemy[] Allenemies;
    private Player[] AllPlayers;
    private AudioSource audioSource;
    [SerializeField] TextMeshProUGUI GameOverText;
    [SerializeField] TextMeshProUGUI RestartText;
    public int pointsP;
    public int pointsM;


    private void Update()
    {
        Webs = GameObject.FindGameObjectsWithTag("Web");
        Allenemies = FindObjectsOfType<Enemy>();
        AllPlayers = FindObjectsOfType<Player>();
        audioSource = FindObjectOfType<AudioSource>();



        if (Webs.Length == 0 || AllPlayers.Length == 0)
        {
            for (int i = 0; i < Allenemies.Length; i++)
            {
                Allenemies[i].enabled = (false);
            }
            for (int i = 0; i < AllPlayers.Length; i++)
            {
                AllPlayers[i].enabled = false;
            }
            audioSource.enabled = false;
            print(AllPlayers.Length);

            if (AllPlayers.Length == 2)
            {
                pointsP = GameObject.Find("spiderman_peter").GetComponent<Player>().returnPoints();
                pointsM = GameObject.Find("spiderman_miles").GetComponent<Player>().returnPoints();
            }

            if (AllPlayers.Length == 1)
            {
                if(GameObject.Find("spiderman_peter") != null)
                {
                    pointsP = GameObject.Find("spiderman_peter").GetComponent<Player>().returnPoints();

                }
                else
                {
                    pointsP = GameObject.Find("GameManager").GetComponent<WinConditions>().pointsP;

                }
                if (GameObject.Find("spiderman_miles") != null)
                {
                    pointsM = GameObject.Find("spiderman_miles").GetComponent<Player>().returnPoints();

                }
                else
                {
                    pointsM = GameObject.Find("GameManager").GetComponent<WinConditions>().pointsM;

                }
            }
            if (AllPlayers.Length != 0)
            {
                RestartText.text = "Press space to restart!";
                if (pointsP > pointsM)
                {
                    GameOverText.color = Color.blue;
                    GameOverText.text = "Peter Wins!";
                }
                else
                {
                    GameOverText.color = Color.red;
                    GameOverText.text = "Miles Wins!";
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

            }
            if (AllPlayers.Length == 0)
            {
                for (int i = 0; i <= 1; i++)
                {
                    pointsP = GameObject.Find("GameManager").GetComponent<WinConditions>().pointsP;
                    pointsM = GameObject.Find("GameManager").GetComponent<WinConditions>().pointsM;

                    print(pointsP);
                    print(pointsM);
                    RestartText.text = "Press space to restart!";
                 
                    if (pointsP > pointsM)
                    {
                        GameOverText.color = Color.blue;

                        GameOverText.text = "Game over, Peter Wins!";
                    }
                    else
                    {
                        GameOverText.color = Color.red;
                        GameOverText.text = "Game over, Miles Wins!";
                    }
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

            }

          
        }


    }
}
