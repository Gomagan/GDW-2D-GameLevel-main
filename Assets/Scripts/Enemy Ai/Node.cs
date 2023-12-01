using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask Wall;
    public LayerMask Enemies;
    public List<Vector2> availableDir {  get; private set; }
    private void Start()
    {
        this.availableDir = new List<Vector2>();

        CheckAvaiableDir(Vector2.up);
        CheckAvaiableDir(Vector2.down);
        CheckAvaiableDir(Vector2.left);
        CheckAvaiableDir(Vector2.right);
    }

    private void CheckAvaiableDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.55f, 0.0f, dir, 1.5f, this.Wall);
        RaycastHit2D hitE = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.55f, 0.0f, dir, 1.5f, this.Enemies);
        if (hit.collider == null && hitE.collider == null)
        {
            this.availableDir.Add(dir);
        }
    }
}
