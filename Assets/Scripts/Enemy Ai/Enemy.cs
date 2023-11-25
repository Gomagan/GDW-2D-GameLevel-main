using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Enemy : EnemyBehavior
{

    public Rigidbody2D rb { get; private set; }
    public EnemyMovement movement {  get; private set; }
  public EnemyChase chase {  get; private set; }
  public EnemyAtBase atBase  {  get; private set; }
  public  EnemyRetreat retreat {  get; private set; }
  public EnemyRegroup regroup{  get; private set; }
  public EnemyBehavior Initbehavior;
  public Transform target;

    private void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.movement = GetComponent<EnemyMovement>();
        this.atBase = GetComponent<EnemyAtBase>();
        this.retreat = GetComponent<EnemyRetreat>();
        this.regroup = GetComponent<EnemyRegroup>();
        this.chase = GetComponent<EnemyChase>();
    }
    private void Start()
    {
        rb.freezeRotation = true;
        ResetState();
    }
    private void Update()
    {
        if (this.target != null)
        {
            return;
        }
        if (this.target == null)
        {
            SwitchTarget();
        }
    }


    void SwitchTarget()
    {

          var targets = GameObject.FindGameObjectsWithTag("Player");
            var Rng = Random.Range(0, targets.Length);
        if (targets.Length > 0)
            {
            target = targets[Rng].transform;
        }
        else
        {
            target = null;

        }
                

                
            
       
    }
    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();
        this.retreat.Disable();
        this.chase.Disable();
        this.regroup.Enable();


        if( this.atBase != this.Initbehavior)
            {
            this.atBase.Disable();
        }
        if (this.Initbehavior != null)
        {
            this.Initbehavior.Enable();
        }
    }
}
