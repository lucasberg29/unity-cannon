using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject enemyPrefab;

    public float playerCreationSpeed;
    public float enemyCreationRadius;

    public float playerCreationTimeLimit;
    private float playerCreationTimeLimitTimeRemaining;

    private List<GameObject> enemyList; 

    void Start()
    {
        enemyList = new List<GameObject>(); 
        playerCreationTimeLimitTimeRemaining = playerCreationTimeLimit;
    }

    void Update()
    {
        if (playerCreationTimeLimitTimeRemaining > 0)
        {
            playerCreationTimeLimitTimeRemaining -= Time.deltaTime;
        }
        else
        {
            playerCreationTimeLimitTimeRemaining = playerCreationTimeLimit;

            Vector2 randomPoint = GetRandomPointOnCircle(enemyCreationRadius);
            CreateEnemy(randomPoint);
        }

    }

    //private void PursuePlayer(GameObject obj)
    //{
    //    Vector3 direction = playerTransform.position - obj.transform.position;
    //    direction.z = playerTransform.position.z;

    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    //    obj.transform.rotation = Quaternion.Euler(0, 0, angle - 90.0f);
    //}

    void CreateEnemy(Vector2 position)
    {
        if (enemyPrefab != null)
        {
            Vector3 enemyPosition = new Vector3(position.x, position.y, -0.05f);

            GameObject enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity, transform);
            enemyList.Add(enemy);
        }
    }

    Vector2 GetRandomPointOnCircle(float radius)
    {
        float angle = Random.Range(0f, 2f * Mathf.PI);

        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);

        return new Vector2(x, y);
    }

    public void KillEnemy(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().isDead = true;
        enemyList.Remove(enemy);
    }

    public void KillAllEnemies()
    {
        foreach (GameObject enemy in enemyList)
        {
            enemy.GetComponent<Enemy>().isDead = true;
        }
    }
}
