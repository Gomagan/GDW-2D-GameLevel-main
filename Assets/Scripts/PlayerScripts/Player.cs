using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    private EnemyRetreat[] er;
    //Getting the move speed and direction for the players
    [Header("Movement")]
    private Vector2 _moveDir;
    [SerializeField] private float _moveSpeed;
    readonly bool _hitWall;

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
            for (int i = 0; i < er.Length; i++)
            {
                er[i].enabled = true;
            }

        }

        if (other.gameObject.tag == "Enemy")
        {
            if (invincible)
            {
                return;
            }
            else
            {
                for (int i = 0; i < er.Length; i++)
                {
                    er[i].enabled = false;
                }
                Destroy(this.gameObject);
            }
        }
    }


    void FixedUpdate()
    {

        er = FindObjectsOfType<EnemyRetreat>();
        //updating the position of the players

        if (_hitWall != true)
          {
              transform.position += (Vector3)(_moveSpeed * Time.fixedDeltaTime * _moveDir);
          }


        pointText.text = characterName + ": " + points;


        if (timeCount > 0)
        {
            invincible = true;
            timeCount -= Time.deltaTime;
        }
        else
        {
            invincible = false;
            for (int i = 0; i < er.Length; i++)
            {
                er[i].enabled = false;
            }

        }

    }
    //letting the code know where the player is going next 
    public void SetMoveDirection(Vector2 newDir)
    {
        _moveDir = newDir;
    }



}
