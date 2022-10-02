using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardEffect : MonoBehaviour
{
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        transform.position =
            new Vector3(playerTransform.position.x,
                playerTransform.position.y + 1.2f,
                0);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
