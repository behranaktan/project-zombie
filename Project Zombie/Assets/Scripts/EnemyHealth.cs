using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private SphereCollider sphereCollider;

    public int maxHealth = 100;
    public int zombieCurrentHealth = 100;
    public HealthBar healthBar;
    public bool enemyDied = false;
    public GameObject coinModel;
    public Transform transform;

    private EnemyAIController enemyAIController;
    private PlayerController playerController;

    private void Start()
    {
        zombieCurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        enemyAIController = GetComponent<EnemyAIController>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void OnTriggerEnter(Collider other)
    {

        TakeDamage(30 + playerController.puan);

    }


    void TakeDamage(int damage)
    {
        zombieCurrentHealth -= damage;
        healthBar.SetHealth(zombieCurrentHealth);

        if (zombieCurrentHealth <= 0)
        {
            enemyDied = true;
            
            MakeDied();
        }
    }

    public void MakeDied()
    {
        enemyAIController.Death();
        Destroy(gameObject,3f);
        DropCoin();
    }

    public void DropCoin()
    {
        Vector3 position = transform.position;
        GameObject coin = Instantiate(coinModel, position+new Vector3(0.0f,1.0f,0.0f) ,quaternion.identity);
        coin.SetActive(true);
        Destroy(coin,8f);
    }

}
