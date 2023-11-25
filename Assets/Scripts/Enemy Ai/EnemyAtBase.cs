using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtBase : EnemyBehavior
{
    public Transform inside;
    public Transform outside;

    private void OnEnable()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(ExitTransition());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.enabled && collision.gameObject.layer == LayerMask.NameToLayer("Wall") )
        {
            this.enemy.movement.SetDirection(-this.enemy.movement.direction);
        }
    }

    private IEnumerator ExitTransition()
    {
        this.enemy.movement.SetDirection(Vector3.up, true);
        this.enemy.movement.rb.isKinematic = true;
        this.enemy.movement.enabled = false;

        Vector3 postition = this.transform.position;

        float duration = 0.5f;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            Vector3 newPostion = Vector3.Lerp(postition, this.inside.position, elapsed / duration);
            newPostion.z = postition.z;
            this.enemy.transform.position = newPostion;
            elapsed += Time.deltaTime;
            yield return null;

        }
        elapsed = 0.0f;

        while (elapsed < duration)
        {
            Vector3 newPostion = Vector3.Lerp(this.inside.position, this.outside.position, elapsed / duration);
            newPostion.z = postition.z;
            this.enemy.transform.position = newPostion;
            elapsed += Time.deltaTime;
            yield return null;


            yield return null;
        }
        this.enemy.movement.SetDirection(new Vector2(Random.value < 0.5f ? -1.0f : 1.0f, 0.0f), true);
        this.enemy.movement.rb.isKinematic = false;
        this.enemy.movement.enabled = true;

    }

}
