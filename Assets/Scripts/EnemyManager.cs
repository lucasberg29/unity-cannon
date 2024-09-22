using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform playerTransform;

    public GameObject enemyPrefab;
    public GameObject alphaEnemyPrefab;

    public float playerCreationSpeed;
    public float enemyCreationRadius;

    public float playerCreationTimeLimit;
    private float playerCreationTimeLimitTimeRemaining;

    private List<GameObject> enemyList;

    private string gameDifficulty;

    void Start()
    {
        enemyList = new List<GameObject>(); 
        playerCreationTimeLimitTimeRemaining = playerCreationTimeLimit;

        gameDifficulty = PlayerPrefs.GetString("Difficulty");
    }

    void Update()
    {
        if (playerCreationTimeLimitTimeRemaining > 0)
        {
            playerCreationTimeLimitTimeRemaining -= Time.deltaTime;
        }
        else
        {
            playerCreationTimeLimit *= 0.95f;
            playerCreationTimeLimitTimeRemaining = playerCreationTimeLimit;

            Vector2 randomPoint = MathUtils.GetRandomPointOnCircle(enemyCreationRadius);
            CreateEnemy(randomPoint);
        }
    }

    void CreateEnemy(Vector2 position)
    {
        Vector3 enemyPosition = new Vector3(position.x, position.y, -0.05f);
        int randomInt = Random.Range(0, 10);

        GameObject enemy = new GameObject();

        switch (gameDifficulty)
        {
            case "Easy":
                enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity, transform);
                enemyList.Add(enemy);
                break;

            case "Regular":
                if (randomInt < 3)
                {
                    enemy = Instantiate(alphaEnemyPrefab, enemyPosition, Quaternion.identity, transform);
                    enemyList.Add(enemy);
                }
                else
                {
                    enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity, transform);
                    enemyList.Add(enemy);
                }
                break;
        }
    }

    public void KillEnemy(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().isDead = true;
        enemyList.Remove(enemy);
    }

    public void KillAllEnemies()
    {
        foreach (GameObject enemyGameObject in enemyList)
        {
            if (enemyGameObject != null)
            {
                enemyGameObject.GetComponent<Enemy>().HurtEnemy(10);
            }
        }
    }
}
