using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;

public class Cannon : MonoBehaviour
{
    float fireTime = 0.5f;
    float timer = 0.0f;
    float rightTimer = 0.0f;

    public GameObject ball;
    public AudioSource gunshot;

    public Transform spawnPoint;
    public Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        timer = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCannonOrientation();

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

    private void UpdateCannonOrientation()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;

        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90.0f);
    }
}
