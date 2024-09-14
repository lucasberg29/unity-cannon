using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI.Extensions.FantasyRPG;


public class Enemy : MonoBehaviour
{
    public bool isDead;

    public int enemyHealth;

    public float enemySpeed = 1.0f;
    public float wingFlapSpeed = 1.0f;

    public static Vector2 startingPosition;

    public Transform tank;
    public Vector2 tankPosition;

    public Score score;

    public AudioSource hitSound;

    public Collider2D collision1;

    public Tank tankObject;

    public EnemyCreator creator;

    public GameObject newEnemyGroup;

    public Animator animator;

    public ParticleSystem particleSystem;

    private EnemyManager enemyManager;

    private Collider2D cannonBallHit;

    void Start()
    {
        enemyManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>();
        
        tank = GameObject.Find("Player").GetComponent<Transform>();
        hitSound = GameObject.Find("Player").GetComponent<AudioSource>();

        startingPosition = tank.position;

        hitSound = gameObject.GetComponent<AudioSource>();

        score = GameObject.Find("Text").GetComponent<Score>();

    }

    void Update()
    {
        if (!isDead)
        {
            PursuePlayer();
        }
    }

    private void PursuePlayer()
    {
        if (tank != null)
        {
            Vector3 direction = tank.position - transform.position;
            direction.z = tank.position.z;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle - 90.0f);

            transform.Translate(Vector2.up * enemySpeed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (isDead)
        {
            return;
        }

        if (hitSound != null)
        {
            hitSound.Play();
        }

        switch(collider.tag)
        {
            case "Player":
                if (hitSound != null)
                {
                    hitSound.Play();
                }

                enemyManager.KillAllEnemies();


                tank.position = GameObject.Find("Player").GetComponent<Tank>().getStartingPosition();

                PlayerPrefs.SetInt("HighestScore", score.GetScore());
                score.ResetScore();

                break;

            case "CannonBall":
                cannonBallHit = collider;
                EnemyDeath();
                break;
        }
    }

    private void EnemyDeath()
    {
        score.addToScore();
        animator.SetBool("IsDead", true);
        enemyManager.KillEnemy(gameObject);
        particleSystem.Play();

        if (cannonBallHit != null)
        {
            Destroy(cannonBallHit.gameObject);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    //public Vector2 getStartingPosition()
    //{
    //    return startingPosition;
    //}
}
