using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 3.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(){
         Instantiate(enemy, transform.position, transform.rotation);
    }
}
