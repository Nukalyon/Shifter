using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    private Vector2 origin;
    [SerializeField]
    private EnemyState currentState = EnemyState.IDLE;
    [SerializeField] private Transform joueur;
    [SerializeField] float chaseRayon;
    [SerializeField] float chaseVitesse;
    [SerializeField] float attackRayon;
    [SerializeField] float attackVitesse;
    [SerializeField] float patrolRayon;
    [SerializeField] float patrolVitesse;

    private void Awake()
    {
        origin = transform.position;
    }

    private void Update()
    {
        switch(currentState)
        {
            case EnemyState.IDLE:
                Idle();
                //Animator.Play("IDLE");
                break;

            case EnemyState.PATROL:
                Patrol();
                //Animator.Play("PATROL");
                break;

            case EnemyState.ATTACK:
                Attack();
                //Animator.Play("ATATCK");
                break;

            case EnemyState.CHASE:
                Chase();
                //Animator.Play("CHASE");
                break;
        }
    }

    #region Etats
    private void Idle()
    {
        //Action

        //Transition
        float distance = Vector2.Distance(this.transform.position, joueur.transform.position);
        if(distance < chaseRayon)
        {
            //this.currentState = EnemyState.CHASE;
            TransitionTo(EnemyState.CHASE);
        }
    }

    private void Patrol()
    {
        //Action
        Vector2 current = this.transform.position;
        Vector2 target = origin;
        float distanceDelta = patrolVitesse * Time.deltaTime;
        this.transform.position = Vector2.MoveTowards(current, target, distanceDelta);

        //Transition
        float distance = Vector2.Distance(this.transform.position, joueur.transform.position);
        if (distance < patrolRayon)
        {
            TransitionTo(EnemyState.IDLE);
        }

    }
    
    private void Attack()
    {
        //Action
        Vector2 current = this.transform.position;
        Vector2 target = joueur.transform.position;
        float distanceDelta = attackVitesse * Time.deltaTime;
        this.transform.position = Vector2.MoveTowards(current, target, distanceDelta);

        //Transition

    }

    private void Chase()
    {
        //Action
        Vector2 current = this.transform.position;
        Vector2 target = joueur.transform.position;
        float distanceDelta = chaseVitesse * Time.deltaTime;
        this.transform.position = Vector2.MoveTowards(current, target, distanceDelta);
        
        //Transition
        float distance = Vector2.Distance(this.transform.position, joueur.transform.position);
        if (distance < attackRayon)
        {
            TransitionTo(EnemyState.ATTACK);
        }
        if(distance > patrolRayon)
        {
            TransitionTo(EnemyState.IDLE);
        }

    }
    #endregion

    //Dessine un truc pour le développeur h24
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, chaseRayon);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRayon);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, patrolRayon);
    }

    //Dessine un truc pour le développeur si l'objet est sélectionné
    private void OnDrawGizmosSelected()
    {
        
    }

    private void TransitionTo(EnemyState nState)
    {
        this.currentState = nState;

        switch (currentState)
        {
            case EnemyState.IDLE:
                //Idle();
                //Animator.Play("IDLE");
                Debug.Log("Idle");
                break;

            case EnemyState.PATROL:
                //Patrol();
                //Animator.Play("PATROL");
                Debug.Log("Patrol");
                break;

            case EnemyState.ATTACK:
                //Attack();
                //Animator.Play("ATATCK");
                Debug.Log("Attack");
                break;

            case EnemyState.CHASE:
                //Chase();
                //Animator.Play("CHASE");
                Debug.Log("Chase");
                break;
        }
    }
}


public enum EnemyState
{
    IDLE,
    PATROL,
    CHASE,
    ATTACK
}