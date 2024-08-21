using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    float fireTime = 0.5f;
    float timer = 0.0f;
    float rightTimer = 0.0f;

    public GameObject ball;
    public Transform spawnPoint;

    public AudioSource gunshot;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        timer = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = 10.0f;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = mousePosition - transform.position;

        float angle = 90.0f - (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);

        timer += Time.deltaTime;

        rightTimer += (4.0f * Time.deltaTime);

        //left click
        if (timer >= fireTime && Input.GetMouseButton(0))
        {
            gunshot.Play();
            Instantiate(ball, spawnPoint.position, transform.rotation);
            
            timer = 0.0f;
        }

        //right click
        int counter = 0;
        if (rightTimer >= fireTime && Input.GetMouseButton(1))
        {
            ++counter;
            gunshot.Play();
            Instantiate(ball, spawnPoint.position, transform.rotation);
            rightTimer = 0.0f;
        }
    }
}
