using System.Collections;
using System.Collections.Generic; // Required for using Lists
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] segment;                   // we have 3 elements in array
    [SerializeField] private int zPos = 50;
    [SerializeField] private int poolSizePerPrefab = 5; // Adjust based on how many fit on screen

    // This List acts as our Object Pool
    private List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        // 1. Pre-instantiate the objects at the start of the game
        foreach (GameObject prefab in segment)              //foreach will run 3 times and nested for loop will run 5 times so total 15 prefabs will be Instantiated
        {
            for (int i = 0; i < poolSizePerPrefab; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false); // Hide them initially
                pool.Add(obj);                //added to pool list 
            }
        }

        // Start the generation loop cleanly
        StartCoroutine(SegmentGen());
    }

    IEnumerator SegmentGen()
    {
        // A while loop replaces the need for the creatingSegment boolean check in Update
        while (true) 
        {
            // 2. Pick a random segment type
            int segmentNum = Random.Range(0, segment.Length);
            GameObject prefabToSpawn = segment[segmentNum];              //stored Right side into variable name prefabToSpawn and its type is GameObject

            // 3. Search the pool for an INACTIVE object of that specific type
            GameObject segmentToUse = null;                         // we created a empty variable segmentToUse
            foreach (GameObject pooledObj in pool)                   //searching the pool of 15 prefabs
            {
                // Check if it is currently hidden AND matches the prefab name
                if (!pooledObj.activeInHierarchy && pooledObj.name.Contains(prefabToSpawn.name))
                {
                    segmentToUse = pooledObj;      //If the clone passes both checks, we take it out of the list and assign it to our variable segmentToUse.
                    break;                         //We found an available segment so break the loop
                }
            }

            // 4. Reposition and Activate
            if (segmentToUse != null)                    //Checks if our variable segmentToUse actually has a segment in it, or if it is still empty (null).
            {
                segmentToUse.transform.position = new Vector3(0, 0, zPos);
                segmentToUse.transform.rotation = Quaternion.identity;
                segmentToUse.SetActive(true);

                zPos += 50;
            }
            else
            {
                Debug.LogWarning("Pool is empty! Increase poolSizePerPrefab.");
            }

            yield return new WaitForSeconds(5.5f);           //Pauses this infinite while loop for 5.5 seconds before allowing it to repeat
        }
    }
}