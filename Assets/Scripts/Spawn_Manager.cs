using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject mercader;
    public GameObject[] spawnPos;

    
    void Start()
    { 
    Instantiate(enemy, spawnPos[0].transform.position, spawnPos[0].transform.rotation);
    Instantiate(enemy, spawnPos[1].transform.position, spawnPos[1].transform.rotation);
    Instantiate(enemy, spawnPos[2].transform.position, spawnPos[2].transform.rotation);
    Instantiate(enemy, spawnPos[3].transform.position, spawnPos[3].transform.rotation);
        Instantiate(mercader, spawnPos[4].transform.position, spawnPos[4].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
