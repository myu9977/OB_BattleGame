using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemyData
{
    public string Name;
    public string Grade;
    public float Speed;
    public int Health;

    public EnemyData(string name, string grade, float speed, int health)
    {
        Name = name;
        Grade = grade;
        Speed = speed;
        Health = health;
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<EnemyData> enemyList = new List<EnemyData>();
    public GameObject enemyPrefab;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        LoadEnemyData("Resources/SampleMonster");  // CSV 파일 경로
        SpawnNextEnemy();
    }

    private void LoadEnemyData(string filePath)
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            bool isFirstLine = true;
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue;
                }
                var values = line.Split(',');

                string name = values[0];
                string grade = values[1];
                float speed = float.Parse(values[2]);
                int health = int.Parse(values[3]);

                EnemyData enemyData = new EnemyData(name, grade, speed, health);
                enemyList.Add(enemyData);
            }
        }
    }

    public void SpawnNextEnemy()
    {
        if (enemyList.Count > 0)
        {
            var enemyData = enemyList[0];
            enemyList.RemoveAt(0);
            SpawnEnemy(enemyData);
        }
        else
        {
            Debug.Log("모든 적이 소환됨");
        }
    }

    private void SpawnEnemy(EnemyData enemyData)
    {
        if (enemyPrefab != null)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyController>().Initialize(enemyData);
        }
    }
}
