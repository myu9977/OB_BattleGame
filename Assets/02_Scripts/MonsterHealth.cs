using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int health;
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
        // Notify the spawner to spawn the next monster
        monsterSpawner.GetComponent<MonsterDataLoad>().SpawnNextMonster();
    }
}
