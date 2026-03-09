using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{

    public GameObject[] smallCones;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        foreach (GameObject cone in smallCones){
            
            cone.SetActive(false);

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
            foreach (GameObject cone in smallCones)
            {
                cone.SetActive(true);

                // Add particle system if it doesn't already have one
                ParticleSystem ps = cone.GetComponent<ParticleSystem>();
                if (ps == null)
                {
                    ps = cone.AddComponent<ParticleSystem>();

                    // Customize the effect here
                    var main = ps.main;
                    main.startColor = Color.red;
                    main.startSize = 0.2f;
                    main.startLifetime = 0.8f;
                    main.startSpeed = 3f;
                    main.duration = 0.5f;
                    main.loop = false;

                    var emission = ps.emission;
                    emission.SetBursts(new ParticleSystem.Burst[] {
                        new ParticleSystem.Burst(0f, 20)
                    });
                    emission.rateOverTime = 0;
                }

                ps.Play();
            }
        }
    }
   
}
