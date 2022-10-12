using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBarThirdPerson : MonoBehaviour
{
    public float startHealth = 100;

    private float health;

    //public GameObject deathEffect;
    public Image healthBar;

    public Color healthyColor = new Color(0.3f, 0.8f, 0.3f);

    public Color unhealthyColor = new Color(0.8f, 0.3f, 0.3f);

    public float damageAmt = 10f;

    private bool canTakeDamage = true;

    private void Start()
    {
        health = startHealth;
    }

    public void SetColor(Color newColor)
    {
        healthBar.GetComponent<Image>().color = newColor;
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "EnemyRoach")
    //     {
    //         TakeDamage (damageAmt);
    //     }
    //     if (collision.gameObject.tag == "EnemyKnifeRoach")
    //     {
    //         TakeDamage(damageAmt * 1.5f);
    //     }
    // }
    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "EnemyRoach")
        {
            if (canTakeDamage)
            {
                StartCoroutine(TakeDamage(damageAmt));
            }
        }
        if (other.gameObject.tag == "EnemyKnifeRoach")
        {
            if (canTakeDamage)
            {
                StartCoroutine(TakeDamage(damageAmt * 1.5f));
            }
        }
    }

    public IEnumerator TakeDamage(float amount)
    {
        canTakeDamage = false;
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        //turn red at low health:
        if (health < 0.3f)
        {
            if ((health * 100f) % 3 <= 0)
            {
                SetColor(Color.white);
                Die();
            }
            else
            {
                SetColor (unhealthyColor);
            }
        }
        else
        {
            SetColor (healthyColor);
        }

        yield return new WaitForSecondsRealtime(0.5f);

        canTakeDamage = true;
    }

    public void Die()
    {
        Debug.Log("You Died So Much");

        // death stuff. change scene? how about a particle effect?
        //Vector3 objPos = this.transform.position
        //Instantiate(deathEffect, objPos, Quaternion.identity) as GameObject;
        SceneManager.LoadScene("DeathScene");
    }
}
