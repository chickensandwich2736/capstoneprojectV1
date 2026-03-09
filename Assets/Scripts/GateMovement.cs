using UnityEngine;

public class GateMovement : MonoBehaviour
{

    public float speed = 0.05f;

    private float upperLimit = -3f;
    private float lowerLimit = -3.6f;

    private int direction = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.up * direction * speed * Time.deltaTime;

        if (transform.localPosition.y >= upperLimit)
        {
            direction = -1;
        }
        if (transform.localPosition.y <= lowerLimit)
        {
            direction = 1;
        }

    }
}
