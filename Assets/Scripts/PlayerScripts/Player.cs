using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    //Getting the move speed and direction for the players
    [Header("Movement")]
    private Vector2 _moveDir;
    [SerializeField] private float _moveSpeed;
    bool _hitWall;

    private float tempSpeed;


    [Header("Points")]
    [SerializeField] private string characterName;
    [SerializeField] private TextMeshProUGUI pointText;
    private int points = 0;



    [Header("Venom Power")]
    [SerializeField] private float invincibilityTime;
    private float timeCount;
    private bool invincible;

    void Start()
    {
    //Activating the InputManager and Controls
        InputManager.Init(this , this);
        InputManager.EnableInGame();

    }



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Web") 
        {
            points += 100;
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Consumable")
        {
            timeCount = invincibilityTime;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            if (invincible)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }


    void Update()
    {
        //updating the position of the players

          if (_hitWall != true)
          {
              transform.position += (Vector3)(_moveSpeed * Time.deltaTime * _moveDir);
          }

          /*
              if (_hitWall == true)
          {
              transform.position += (Vector3)(_moveDir * 0);
          }
           */


        pointText.text = characterName + ": " + points;


        if (timeCount > 0)
        {
            invincible = true;
            timeCount -= Time.deltaTime;
        }
        else
        {
            invincible = false;
        }

    }
    //letting the code know where the player is going next 
    public void SetMoveDirection(Vector2 newDir)
    {
        _moveDir = newDir;
    }



}
