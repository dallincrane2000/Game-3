using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    public float health, maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        OnPlayerDamaged?.Invoke();

        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
            Debug.Log("Player Dead");
            OnPlayerDeath?.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Here");
        if(other.tag == "EnemyBullet")
        {
            TakeDamage(1);
        }
    }
    /*public void UpdateHealth(float mod)
    {
        health += mod;
        Debug.Log(health);

        if (health > maxHealth)
        {
            health = maxHealth;
        } else if (health <= 0f)
        {
            health = 0f;
            Debug.Log("Player Dead");
        }
    }*/

    
}
