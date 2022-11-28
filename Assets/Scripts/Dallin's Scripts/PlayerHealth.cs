using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

     private GameObject healthManager;

    public float health, maxHealth, bulletDamage;

    public AudioSource PlayerDamage;

    private void Start()
    {
        healthManager = GameObject.Find("HealthManager");
        health = healthManager.GetComponent<healthManager>().health;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        PlayerDamage.Play();
        healthManager.GetComponent<healthManager>().health = health;
        OnPlayerDamaged?.Invoke();

        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
            Debug.Log("Player Dead");
            OnPlayerDeath?.Invoke();
            SceneManager.LoadScene(6);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Here");
        if(other.tag == "EnemyBullet")
        {
            TakeDamage(bulletDamage);
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
