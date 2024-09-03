using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string enemyName;
    public string grade;
    public float speed;
    public int maxHealth;
    public int currentHealth;

    public void Initialize(EnemyData data)
    {
        enemyName = data.Name;
        grade = data.Grade;
        speed = data.Speed;
        maxHealth = data.Health;
        currentHealth = maxHealth;

        GetComponent<Rigidbody>().velocity = new Vector3(-speed, 0, 0); // 가로 방향 이동
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        
        GameManager.Instance.SpawnNextEnemy();  // 다음 적을 소환
    }
}
