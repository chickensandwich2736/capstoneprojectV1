using UnityEngine;

public class PlateDisappearTrigger : MonoBehaviour
{

    public GameObject movingPlate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            movingPlate.GetComponent<MovePlate>().startMoving = false;
            movingPlate.SetActive(false);
        }
    }
}
