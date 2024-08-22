using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform tankPosition;
    private Vector2 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition = new Vector2(tankPosition.position.x, tankPosition.position.y);
        transform.position = new Vector3(cameraPosition.x, cameraPosition.y, -48);
    }
}
