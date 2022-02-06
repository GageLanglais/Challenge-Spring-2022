using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform start;
    public Transform end;


    public float speed;

    private float startTime;

    private float journey;

    void Start()
    {
        startTime = Time.time;

        journey = Vector2.Distance(start.position, end.position);
    }

    void Update()
    {
        float distance = (Time.time - startTime) * speed;
        float fracJourney = distance / journey;
        transform.position = Vector2.Lerp(start.position, end.position, Mathf.PingPong (fracJourney, 1));
    }

    

}
