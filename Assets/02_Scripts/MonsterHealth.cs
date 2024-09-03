using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int health;
    public string grade;
    public string name;
    public GameObject monsterSpawner;

    private void Awake()
    {
        if (monsterSpawner == null)
        {
            monsterSpawner = GameObject.FindObjectOfType<MonsterDataLoad>().gameObject;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"몬스터 : {name} / 대미지 :  {damage} / 남은체력 : {health}");
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{name} 죽음");
        Destroy(gameObject);
        monsterSpawner.GetComponent<MonsterDataLoad>().SpawnNextMonster();
    }
}