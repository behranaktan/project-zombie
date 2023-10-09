using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;
    
    //Devriye
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    
    //Saldırma
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    
    //durum kontrolü
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    Animator animator;

    BoxCollider boxCollider;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider>();

    }


    private void Update()
    {
        //oyuncunun görüş veya saldırı mesafesinde olup olmadığını kontrol eder.
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)  Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;

    }

    private void SearchWalkPoint()
    {
        //rastgele mesafe hesaplar
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
        
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        animator.SetTrigger("Attack");
        agent.SetDestination(transform.position);
        
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    
    void EnableAttack()
    {
        boxCollider.enabled = true;
    }

    void DisableAttack()
    {
        boxCollider.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            health -= 20;
        }
    }

    public void Death()
    {
        agent.speed = 0f;
        animator.SetTrigger("Death");
    }
}
