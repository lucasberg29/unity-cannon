using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform tankPosition;

    private static Vector2 Cameraposition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cameraposition = new Vector2(tankPosition.position.x, tankPosition.position.y);
        transform.position = new Vector3(Cameraposition.x, Cameraposition.y, -48);
    }
}
