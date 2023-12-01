using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyRetreat : EnemyBehavior
{
    [SerializeField] private AudioSource Source;
    [SerializeField] private AudioClip R_DeathSound;
    [SerializeField] private AudioClip S_DeathSound;
    [SerializeField] private AudioClip G_DeathSound;
    public bool wounded {  get;  set; }

    private void OnEnable()
    {
        this.enemy.movement.speedMultiplier = 0.5f;
        this.wounded = false;
    }
    private void OnDisable()
    {
        this.enemy.movement.speedMultiplier = 1f;
        this.wounded = false;
    }

    private void Wounded()
    {
        this.wounded = true;

        if (this.enemy.name == "Rhino")
        {
            Source.PlayOneShot(R_DeathSound);
        }
        if (this.enemy.name == "GreenGoblin")
        {
            Source.PlayOneShot(G_DeathSound);

        }
        if (this.enemy.name == "Scorpion")
        {
            Source.PlayOneShot(S_DeathSound);
        }
        Vector3 postion = this.enemy.atBase.inside.position;
        postion.z = this.enemy.transform.position.z;
        this.enemy.transform.position = postion;    
        this.enemy.atBase.Enable(this.duration);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        { 
            if (this.enabled)
            {
                Wounded();

            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();
        if (node != null && this.enabled )
        {
            Vector2 direction = Vector2.zero;
            float MaxDistance = float.MinValue;

            foreach (Vector2 availableDirection in node.availableDir)
            {
                Vector3 newPos = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);
                float distance = (this.enemy.target.position - newPos).sqrMagnitude;

                if (distance > MaxDistance)
                {
                    direction = availableDirection;
                    MaxDistance = distance;
                }
            }
            this.enemy.movement.SetDirection(direction);
        }
    }
}
