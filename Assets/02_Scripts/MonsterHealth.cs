using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int health;
    public string grade;
    public string name;
    public GameObject monsterSpawner;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        monsterSpawner.GetComponent<MonsterDataLoad>().SpawnNextMonster();
    }
}
