using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    public float lerpRate;
    public bool gameOver;
    //distance between  camera and ball
    Vector3 offset;
    void Start()
    {
        offset = ball.transform.position - transform.position;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Follow();
        }
    }
    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
