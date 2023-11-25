using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyBehavior
{
    PlayerController pl;

    private void OnDisable()
    {
        this.enemy.regroup.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        Node node = other.GetComponent<Node>();
        if (node != null && this.enabled && !this.enemy.retreat.enabled) 
        {
           
            
            Vector2 direction = Vector2.zero;
           float minDistance = float.MaxValue;

           foreach (Vector2 availableDirection in node.availableDir)
            {
                Vector3 newPos = this.transform.position + new Vector3(availableDirection.x, availableDirection.y, 0.0f);
              
                float distance = (this.enemy.target.position - newPos).sqrMagnitude;

                if (distance < minDistance)
                {
                    direction = availableDirection;
                    minDistance = distance;
                }
            }
           this.enemy.movement.SetDirection(direction);
        }
    }
}
