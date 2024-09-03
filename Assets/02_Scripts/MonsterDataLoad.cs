using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class MonsterDataLoad : MonoBehaviour
{
    public TextAsset csvFile;
    public Transform monsterSpawner;
    private Queue<MonsterData> monstersQueue = new Queue<MonsterData>();

    void Start()
    {
        ParseCSV();
        SpawnNextMonster();
    }

    void ParseCSV()
    {
        StringReader reader = new StringReader(csvFile.text);
        string headerLine = reader.ReadLine();
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');

            string name = values[0];
            string grade = values[1];

            float speed;
            if (!float.TryParse(values[2], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out speed))
            {
                continue;
            }

            int health;
            if (!int.TryParse(values[3], out health))
            {
                continue;
            }

            MonsterData data = new MonsterData(name, grade, speed, health);
            monstersQueue.Enqueue(data);
        }
    }

    public void SpawnNextMonster()
    {
        if (monstersQueue.Count > 0)
        {
            MonsterData data = monstersQueue.Dequeue();
            GameObject monsterPrefab = Resources.Load<GameObject>(data.name);
            if (monsterPrefab != null)
            {
                Vector3 spawnPosition = monsterSpawner != null ? monsterSpawner.position : new Vector3(10, 0, 0);
                GameObject monster = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
                MonsterHealth healthComponent = monster.GetComponent<MonsterHealth>();
                if (healthComponent != null)
                {
                    healthComponent.health = data.health;
                    healthComponent.grade = data.grade;
                    healthComponent.name = data.name;
                }
                MonsterMovement movementComponent = monster.GetComponent<MonsterMovement>();
                if (movementComponent != null)
                {
                    movementComponent.speed = data.speed;
                }
            }
            else
            {
                Debug.LogError("몬스터 프리팹 못찾음 " + data.name);
            }
        }
    }
}

[System.Serializable]
public class MonsterData
{
    public string name;
    public string grade;
    public float speed;
    public int health;

    public MonsterData(string name, string grade, float speed, int health)
    {
        this.name = name;
        this.grade = grade;
        this.speed = speed;
        this.health = health;
    }
}