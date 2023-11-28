using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private EnemyState etatActuel = EnemyState.IDLE;

    [SerializeField] Transform joueur;

    [SerializeField] float chaseRayon;
    [SerializeField] float chaseVitesse;


    [SerializeField] float attackRayon;
    [SerializeField] float attackVitesse;

    [SerializeField] float patrolRayon;
    [SerializeField] float patrolVitesse;

    private Vector3 pointDepart;

    private void Awake()
    {
        pointDepart = this.transform.position;
    }
    public void TransitionTo(EnemyState newState)
    {
        etatActuel = newState;

        switch (etatActuel) 
        {
            case EnemyState.IDLE:
                //Animator.Play("IDLE")
                break;
            case EnemyState.PATROL:
                //Animator.Play("PATROL")
                Debug.Log("Patrol Animation!");

                break;
            case EnemyState.CHASE:
                //Animator.Play("CHASE")
                Debug.Log("");

                break;
            case EnemyState.ATTACK:
                //Animator.Play("ATTACK")

                break;    
        }
    }
    private void Idle()
    {
        float dist = Vector2.Distance(this.transform.position, joueur.transform.position);
        if(dist < chaseRayon)
        {
            TransitionTo(EnemyState.CHASE);
        }
    }

    // Update is called once per frame
    private void Patrol()
    {
        //Action
        this.transform.position = Vector2.MoveTowards(this.transform.position, pointDepart, patrolVitesse * Time.deltaTime);

        //Transition(s)
        float distPatrol = Vector2.Distance(this.transform.position, pointDepart);
        if(distPatrol < 0.1f)
        {
            TransitionTo(EnemyState.IDLE);
        }

        float distChase = Vector2.Distance(this.transform.position, joueur.transform.position);
        if(distChase < chaseRayon)
        {
            TransitionTo(EnemyState.CHASE);
        }
    }
    private void Chase()
    {
        //Action
        this.transform.position = Vector2.MoveTowards(this.transform.position, joueur.transform.position, chaseVitesse * Time.deltaTime);

        //Transition(s)
        float dist = Vector2.Distance(this.transform.position, joueur.transform.position);
        if (dist < attackRayon)
        {
            TransitionTo(EnemyState.ATTACK);


        }
        if (dist < patrolRayon)
        {
            TransitionTo(EnemyState.PATROL);


        }
    }
    private void Attack()
    {
        //Action
        this.transform.position = Vector2.MoveTowards(this.transform.position, joueur.transform.position, attackVitesse * Time.deltaTime);

        //Transition(s)
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Vector4(0, 0, 0, 1);
        Gizmos.DrawWireSphere(this.transform.position, patrolRayon);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, chaseRayon);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRayon);
    }
    public enum EnemyState
    {
        IDLE,
        PATROL,
        CHASE,
        ATTACK
    }
        
}
