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

    //temporary time variables:
    public float timeToDamage = 5f;

    private float theTimer;

    public float damageAmt = 10f;

    private void Start()
    {
        health = startHealth;
        theTimer = timeToDamage;
    }

    // this timer is just to test damage. Comment-out when no longer needed
    void FixedUpdate()
    {
        theTimer -= Time.deltaTime;
        if (theTimer <= 0)
        {
            TakeDamage (damageAmt);
            theTimer = timeToDamage;
        }
    }

    public void SetColor(Color newColor)
    {
        healthBar.GetComponent<Image>().color = newColor;
    }

    public void TakeDamage(float amount)
    {
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
    }

    public void Die()
    {
        Debug.Log("You Died So Much");
        // death stuff. change scene? how about a particle effect?
        //Vector3 objPos = this.transform.position
        //Instantiate(deathEffect, objPos, Quaternion.identity) as GameObject;
        //SceneManager.LoadScene ("Scene_lose");
    }
}
