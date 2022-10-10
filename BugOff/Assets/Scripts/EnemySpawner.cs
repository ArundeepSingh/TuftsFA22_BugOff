using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    private int waveNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 3, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {   
        GameObject enem = (waveNum % 3 == 0) ? enemy2 : enemy1;
        Instantiate(enem, transform.position, transform.rotation);
        waveNum += 1;
    }
}
