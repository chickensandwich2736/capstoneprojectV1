using UnityEngine;

public class WreckingBallSwing : MonoBehaviour
{

    public float swingAngle = 15f;
    public float swingSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
        transform.localRotation = Quaternion.Euler(0,0,angle);
    }
}
