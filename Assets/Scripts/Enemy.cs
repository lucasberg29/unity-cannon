using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    public Transform tank;
    public static Vector2 startingPosition;
    public Vector2 tankPosition;

    public Score score;

    public Collider2D thiscollider;
    public AudioSource hitsound;

    public RefreshMenu refresh;

    public Collider2D collision1;

    public Tank tankObject;

    public EnemyCreator creator;

    public GameObject newEnemyGroup;

    
    // Start is called before the first frame update
    void Start()
    {
        refresh = null;
        thiscollider = gameObject.GetComponent<Collider2D>();
        
        tank = GameObject.Find("Player").GetComponent<Transform>();
        startingPosition = tank.position;

        hitsound = gameObject.GetComponent<AudioSource>();

        score = GameObject.Find("Text").GetComponent<Score>();
        refresh = GameObject.Find("Main Camera").GetComponent<RefreshMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        PursuePlayer();
    }

    private void PursuePlayer()
    {
        Vector3 direction = tank.position - transform.position;
        direction.z = tank.position.z;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 90.0f);

        transform.Translate(Vector2.up * 2.0f * Time.deltaTime);
    }

    private void UpdateEnemyPosition()
    {
        transform.Translate(Vector2.up * 2.0f * Time.deltaTime);

        Vector3 dir = tank.position - transform.position;
        float angle = 90.0f - Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        hitsound.Play();

        string gameObjectTag = collider.tag;

        switch(gameObjectTag)
        {
            case "Player":
                hitsound = GameObject.Find("Player").GetComponent<AudioSource>();

                hitsound.Play();
                tank.position = GameObject.Find("Player").GetComponent<Tank>().getStartingPosition();

                score.ResetScore();
                break;

            case "CannonBall":
                score.addToScore();
                KillEnemy();
                break;
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    public Vector2 getStartingPosition()
    {
        return startingPosition;
    }
}
