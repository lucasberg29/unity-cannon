using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public float difficulty;
    public float timer;
    public float respawnTime = 0.0f;

    public float spawnRadius = 100.0f;

    public Transform enemyPosition;
    public Transform tankPosition;
    public GameObject enemy;

    public IslandDIfficulty level;

    public GameObject prefabParent;

    // Start is called before the first frame update
    void Start()
    {
        timer = 5.0f;
        difficulty = 1.0f;
        level = GameObject.Find("Main Camera").GetComponent<IslandDIfficulty>();

        difficulty = level.getDifficulty();
        timer = timer - 4.0f *difficulty;
        Instantiate(prefabParent, enemyPosition.position, enemyPosition.rotation); 
    }

    // Update is called once per frame
    void Update()
    {
        respawnTime = respawnTime + Time.deltaTime;

        if (respawnTime > timer)
        {
            createEnemy();
            
            respawnTime = respawnTime % timer;
        }
    }

    public void createEnemy()
    {
        Vector3 spawn3 = Random.insideUnitCircle.normalized;

        enemyPosition.position = new Vector3(spawn3.x * spawnRadius, spawn3.y * spawnRadius, 0.0f);

        GameObject temp = Instantiate(enemy, enemyPosition.position, enemyPosition.rotation);        

        temp.transform.parent = GameObject.Find("EnemiesParent(Clone)").transform;
    }

}
