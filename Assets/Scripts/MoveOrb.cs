using UnityEngine;

public class MoveOrb : MonoBehaviour
{

    public float speed = 11.05f;
    public float turnSpeed = 240f;
    private Rigidbody rb;
    private bool isAlive = true;
    private float currentYRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentYRotation = transform.eulerAngles.y;
        Debug.Log("Speed starts at: " + speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!isAlive)
        {
            return;
        }

        if (transform.position.y < -8f)
        {
            Debug.Log("Fell off the map");
            LoseGame();
            return;
        }

        rb.AddForce(Vector3.down * 25f, ForceMode.Acceleration);

        float turn = Input.GetAxisRaw("Horizontal");
        currentYRotation += turn * turnSpeed * Time.fixedDeltaTime;

        Quaternion targetRotation = Quaternion.Euler(0f, currentYRotation, 0f);
        rb.MoveRotation(targetRotation);

        //float rotationAmount = turn * turnSpeed * Time.fixedDeltaTime;
        //transform.Rotate(0f, rotationAmount, 0f);

        Vector3 forwardMove = targetRotation * Vector3.forward * speed;
        rb.linearVelocity = new Vector3(forwardMove.x,rb.linearVelocity.y,forwardMove.z);


    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isAlive)
        {
            return;
        }

        //Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Spike"))
        {
            LoseGame();
        }

        if (collision.gameObject.CompareTag("ChangeSpeedS3"))
        {
            speed = 10f;
            Debug.Log("Speed changed to: " + speed);
        }

        if (collision.gameObject.CompareTag("ChangeSpeedS5"))
        {
            speed = 11.05f;
            Debug.Log("Speed changed to: " + speed);
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChangeSpeedS3Revert"))
        {
            speed = 11.05f;
            Debug.Log("Speed changed to: " + speed);
        }

        if (other.CompareTag("ChangeSpeedS4"))
        {
            speed = 13.0f;
            Debug.Log("Speed changed to: " + speed);
        }
    }

    void LoseGame()
    {
        isAlive = false;

        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;

        gameObject.SetActive(false);
    }
}
