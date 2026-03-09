using UnityEngine;



public class MovePlate : MonoBehaviour
{

    public bool startMoving = false;
    private MoveOrb moveOrbScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startMoving && moveOrbScript != null)
        {
            transform.Translate(Vector3.forward * moveOrbScript.speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            startMoving = true;
            moveOrbScript = collision.gameObject.GetComponent<MoveOrb>();
        }
    }
}
