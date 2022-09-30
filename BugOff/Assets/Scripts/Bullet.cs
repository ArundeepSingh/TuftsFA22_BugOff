using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffectAnim;

    //if bullet hits a collider, play explosion animation, then destroy effect and bullet
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            GameObject animEffect =
                Instantiate(hitEffectAnim,
                transform.position,
                Quaternion.identity);
            Destroy(animEffect, 0.5f);
            Destroy (gameObject);
        }
    }
}
