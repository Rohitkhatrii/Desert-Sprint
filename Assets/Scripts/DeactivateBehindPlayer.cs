using UnityEngine;

public class DeactivateBehindPlayer : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        // Find the player object by its tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // to simply check if the player is ahead 
        if (transform.position.z < player.position.z - 60f) 
        {
            // Deactivate it so the SegmentGenerator pool can use it again
            gameObject.SetActive(false);
        }
    }
}