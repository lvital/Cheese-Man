using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public float speed = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FloorMovement();
    }

    private void FloorMovement()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
    }
}
