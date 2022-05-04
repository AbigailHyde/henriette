using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawn : MonoBehaviour
{
    public GameObject speedUp;
    private float spawnRange = 25.0f;
    private static float countdown;


    // Start is called before the first frame update
    void Start()
    {
        countdown = 90;
    }

    // Update is called once per frame
    void Update()
    {
        //logic to spawn powerups here :)
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        } else if (countdown <= 0)
        {
            spawn();
            countdown = 30;
        }
    }

    public void spawn()
    {
        Instantiate(speedUp, GenerateSpawnPosition(), speedUp.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 1.0f, spawnPosZ);
        return randomPos;
    }
}
