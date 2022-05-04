using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChick : MonoBehaviour
{
    public GameObject chickie;
    private float spawnRange = 25.0f;
    public static int chickCount = 15;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnChicks(chickCount);
        Debug.Log("chickn");
    }

    public void spawnChicks(int chickCount)
    {
        for (int i = 0; i < chickCount; i++)
        {
            Instantiate(chickie, GenerateSpawnPosition(), chickie.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, .796f, spawnPosZ);
        return randomPos;
    }
}
