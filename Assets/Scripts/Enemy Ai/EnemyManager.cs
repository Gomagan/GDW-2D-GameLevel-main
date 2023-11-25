using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy[] enemies;
    public void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        NewRound();
    }

    private void NewRound()
    {
        ResetState();
    }

    private void ResetState()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            this.enemies[i].gameObject.SetActive(true);
        }
    }


}
