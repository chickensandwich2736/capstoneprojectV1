using UnityEngine;

public class InvisTrigger : MonoBehaviour
{

    public GameObject[] pillars;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject pillar in pillars)
        {
            pillar.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject pillar in pillars)
            {
                pillar.SetActive(true);
            }
        }
    }
}
