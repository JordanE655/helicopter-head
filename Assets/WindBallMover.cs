using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBallMover : MonoBehaviour
{

    public Transform startPoint;
    public Transform endPoint;
    public float speed;
    private float timer;

    // Start is called before the first frame update
    void Awake()
    {
        timer = 0f;
        if (speed == 0)
        {
            speed = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(
            Mathf.Lerp(startPoint.position.x, endPoint.position.x, timer/speed),
            Mathf.Lerp(startPoint.position.y, endPoint.position.y, timer/speed),
            Mathf.Lerp(startPoint.position.z, endPoint.position.z, timer/speed)
            );
        if (transform.position == endPoint.position)
        {
            var pointHolder = endPoint;
            endPoint = startPoint;
            startPoint = pointHolder;
            timer = 0;
        }
    }
}
