using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tank : MonoBehaviour
{
    public float tankSpeed;
    public float rotation;
    public Vector2 startingPosition;

    public AudioSource losingSound;
    public RefreshMenu refresh;

    void Start()
    {
        startingPosition = transform.position;
        //losingSound = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * tankSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -rotation * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * tankSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, rotation * Time.deltaTime);
        }
    }

    public Vector2 getStartingPosition()
    {
        return startingPosition;
    }
}
