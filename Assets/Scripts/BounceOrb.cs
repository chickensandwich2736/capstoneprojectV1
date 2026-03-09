using UnityEngine;

public class BounceOrb : MonoBehaviour
{
    public float bounceVelocity = 20f;
    public float extraBounceVelocity = 50f;
    public float extraBounceVelocity2 = 32f;
    public float speedBoost = 9.7f;
    public float speedBoostDuration = 1.7f;
    private float currentBounceStrength;
    private bool applySpeedBoost = false;
    private bool isBoosted = false;
    private float boostTimer = 0f;

    private Rigidbody rb;
    private MoveOrb moveOrb;
    private bool bounceQueued;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveOrb = GetComponent<MoveOrb>();
    }

    void Update()
    {
        if (isBoosted)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer <= 0f)
            {
                moveOrb.speed -= speedBoost;
                isBoosted = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            currentBounceStrength = bounceVelocity;
            bounceQueued = true;
        }
        else if (collision.gameObject.CompareTag("TrampolineExtra"))
        {
            currentBounceStrength = extraBounceVelocity;
            bounceQueued = true;
        }
        else if (collision.gameObject.CompareTag("TrampolineExtra2"))
        {
            currentBounceStrength = extraBounceVelocity2;
            bounceQueued = true;
        }
        else if (collision.gameObject.CompareTag("TrampolineExtra3"))
        {
            currentBounceStrength = extraBounceVelocity2;
            bounceQueued = true;
            applySpeedBoost = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerTramp"))
        {
            currentBounceStrength = bounceVelocity;
            bounceQueued = true;
        }

        if (other.CompareTag("BumperTriggerTramp"))
        {
            currentBounceStrength = extraBounceVelocity2 + 10;
            bounceQueued = true;
        }
    }

    void FixedUpdate()
    {
        if (!bounceQueued)
        {
            return;
        }
        bounceQueued = false;

        Vector3 v = rb.linearVelocity;
        if (v.y < 0f)
        {
            v.y = 0f;
        }

        v.y = currentBounceStrength;
        rb.linearVelocity = v;

        if (applySpeedBoost && !isBoosted)
        {
            applySpeedBoost = false;
            moveOrb.speed += speedBoost;
            isBoosted = true;
            boostTimer = speedBoostDuration;
        }
    }
}

