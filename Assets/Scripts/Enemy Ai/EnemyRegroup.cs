using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyRegroup : EnemyBehavior
{
    PlayerController pl;


    private void OnDisable()
    {
        this.enemy.chase.Enable();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();
     
        
        if (node != null && this.enabled && !this.enemy.retreat.enabled)
        {
            int index = Random.Range(0, node.availableDir.Count);

            if (node.availableDir[index] == -this.enemy.movement.direction && node.availableDir.Count > 1)
            {
                index++;
            }
            if(index >= node.availableDir.Count)
            {
                index = 0;
            }
            this.enemy.movement.SetDirection(node.availableDir[index]);
        }
    }
}
