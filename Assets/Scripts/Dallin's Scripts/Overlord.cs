using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlord : MonoBehaviour
{
    // Split into four gameobjects when health = 0
    public float speed = 3f;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    public float health = 10.0f;
    public Vector3 firstPosition;
    public float gap = 2;
    public GameObject smallerClone;
    public float cloneAmount = 4;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            Vector3 position = firstPosition;
            for (int i = 0; i < cloneAmount; i++)
            {
                Instantiate(smallerClone, position, Quaternion.identity);
                position.x += gap;
            }
        }
    }


}
