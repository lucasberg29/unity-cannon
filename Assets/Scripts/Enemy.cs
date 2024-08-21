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
        Physics2D.IgnoreCollision(GameObject.Find("MapCollider").GetComponent<Collider2D>(),thiscollider);
        
        tank = GameObject.Find("Tank").GetComponent<Transform>();
        startingPosition = tank.position;

        hitsound = gameObject.GetComponent<AudioSource>();


        score = GameObject.Find("Text").GetComponent<Score>();
        refresh = GameObject.Find("Main Camera").GetComponent<RefreshMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * 2.0f * Time.deltaTime);

        Vector3 dir = tank.position - transform.position;
        float angle = 90.0f - Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        hitsound.Play();
        if (collider.gameObject.name == "Tank")
        {
            hitsound = GameObject.Find("Tank").GetComponent<AudioSource>();

            hitsound.Play();

            tank.position = GameObject.Find("Tank").GetComponent<Tank>().getStartingPosition();

            Destroy(GameObject.Find("EnemiesParent(Clone)"));

            Instantiate(newEnemyGroup, new Vector3(0,0,0), Quaternion.identity);

            tank.eulerAngles = new Vector3(0, 0, 0);

            transform.position = startingPosition;
            
            score.ResetScore();
        }
        else 
        {
            score.addToScore();
            Destroy(gameObject);
        }
    }

    public Vector2 getStartingPosition()
    {
        return startingPosition;
    }
}
