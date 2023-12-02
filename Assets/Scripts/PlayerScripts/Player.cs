using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    private EnemyRetreat[] er;
    private int swap;
    //Getting the move speed and direction for the players
    [Header("Movement")]
    private Vector2 _moveDir;
    [SerializeField] private float _moveSpeed;
    readonly bool _hitWall;
    [SerializeField] private WinConditions wl;
    private float tempSpeed;


    [Header("Points")]
    [SerializeField] private string characterName;
    [SerializeField] private TextMeshProUGUI pointText;
    private int points = 0;



    [Header("Venom Power")]
    [SerializeField] private float invincibilityTime;
    [SerializeField] private TextMeshProUGUI venomTime;
    private float timeCount;
    private bool invincible;
    private int timeInt;

    void Start()
    {
        //Activating the InputManager and Controls
        InputManager.Init(this, this);
        InputManager.EnableInGame();
        swap = 0;
    }



   private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Web")
        {
            points += 100;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Consumable")
        {
            timeCount = invincibilityTime;
            Destroy(other.gameObject);
            print(true);
            for (int i = 0; i < er.Length; i++)
            {
                print(false);
                er[i].enabled = true;
            }

        }

        if (other.gameObject.tag == "Enemy")
        {
            if (invincible)
            {
                points += 300;
                return;
            }
            else
            {
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

        if (timeCount < 0)
        {
            timeCount = 0;
            invincible = false;
            for (int i = 0; i < er.Length; i++)
            {
                er[i].enabled = false;
            }
            
        }
        timeInt = (int)timeCount;
        venomTime.text = timeInt.ToString();

    }

    private void OnDestroy()
    {
      if (gameObject.name == ("spiderman_peter"))
        {
            wl.pointsP = 0 + points;
        }
      if (gameObject.name == ("spiderman_miles"))
        {
            wl.pointsM = 0 + points;
        }

    }
    //letting the code know where the player is going next 
    public void SetMoveDirection(Vector2 newDir)
    {
        _moveDir = newDir;
    }

    public int returnPoints()
    {
        return points;
    }
}
