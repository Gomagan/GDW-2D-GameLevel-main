using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float speedMultiplier = 1.0f;
    public Vector2 initDir;
    public LayerMask Wall;
    public Rigidbody2D rb {  get; private set; }
    public Vector2 direction {  get; private set; }
    public Vector2 nextDir { get; private set; }

    private void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.speedMultiplier = 1.0f;
        this.nextDir = Vector2.zero;
        this.direction = this.initDir;
        this.rb.isKinematic = false;
    }

    public void SetDirection(Vector2 direction,bool forced = false)
    {
        if (forced || !Occupied(direction))
        {
            this.direction = direction;
            this.nextDir = Vector2.zero;
        }
        else
        {
            this.nextDir = direction;
        }
    }

    public bool Occupied (Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.0f, this.Wall);
        return hit.collider != null;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = this.rb.position;
        Vector2 translation = this.direction * this.speed * this.speedMultiplier * Time.fixedDeltaTime;
        this.rb.MovePosition(position + translation);
    }
}
