using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D.velocity = Vector2.up * 10.0f * Time.deltaTime;
    }

    void Update()
    {
        transform.Translate(Vector3.up * 10.0f * Time.deltaTime);
        Object.Destroy(gameObject, 10.0f);
    }
}
