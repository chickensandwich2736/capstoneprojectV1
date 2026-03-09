using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset = new Vector3(0f,1.5f,-1.53f);
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (player == null || !player.activeInHierarchy)
        {
            return;
        }

        Vector3 rotatedOffset = player.transform.rotation * offset;
        transform.position = player.transform.position + rotatedOffset;

        float playerYRotation = player.transform.eulerAngles.y;

        float cameraTilt = 22f; 

        transform.rotation = Quaternion.Euler(cameraTilt, playerYRotation, 0f);
    }

    
}
