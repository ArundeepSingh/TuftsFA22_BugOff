using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardEffect : MonoBehaviour
{
    // void Update()
    // {
    //     transform
    //         .LookAt(transform.position +
    //         Camera.main.transform.rotation * -Vector3.back,
    //         Camera.main.transform.rotation * -Vector3.down);
    // }
    // void Update()
    // {
    //     Camera camera = Camera.main;
    //     transform
    //         .LookAt(transform.position +
    //         camera.transform.rotation * Vector3.forward,
    //         camera.transform.rotation * Vector3.up);
    // }
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}

//OR TRY:

//OR TRY:
