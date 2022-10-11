using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoveHit : MonoBehaviour
{
    public Animator anim;

    public Rigidbody2D rb2D;

    public float speed = 4f;

    private Transform target;

    public int damage = 10;

    public int EnemyLives = 2;

    private float knockBackForce = 1500f;

    //    private GameHandler gameHandler;
    public float attackRange = 5;

    public bool isAttacking = false;

    private float scaleX;

    public GameObject bugsExterminatedText;

    public GameObject gameController;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb2D = GetComponentInChildren<Rigidbody2D>();
        scaleX = gameObject.transform.localScale.x;

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            target =
                GameObject
                    .FindGameObjectWithTag("Player")
                    .GetComponent<Transform>();
        }

        gameController =
            GameObject
                .FindGameObjectWithTag("GameController")
                .GetComponent<GameController>()
                .gameObject;

        bugsExterminatedText =
            GameObject.Find("ExterminatedText").GetComponent<Text>().gameObject;

        //   if (GameObject.FindWithTag ("GameHandler") != null) {
        //       gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
        //   }
    }

    void Update()
    {
        float DistToPlayer =
            Vector3.Distance(transform.position, target.position);

        if ((target != null) && (DistToPlayer <= attackRange))
        {
            transform.position =
                Vector2
                    .MoveTowards(transform.position,
                    target.position,
                    speed * Time.deltaTime);

            //anim.SetBool("Walk", true);
            //flip enemy to face player direction. Wrong direction? Swap the * -1.
            if (target.position.x > gameObject.transform.position.x)
            {
                gameObject.transform.localScale =
                    new Vector2(scaleX, gameObject.transform.localScale.y);
            }
            else
            {
                gameObject.transform.localScale =
                    new Vector2(scaleX * -1, gameObject.transform.localScale.y);
            }
        }
        //else { anim.SetBool("Walk", false);}
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isAttacking = true;

            //anim.SetBool("Attack", true);
            //  gameHandler.playerGetHit(damage);
            // calculate force vector
            var force = transform.position - other.transform.position;

            // normalize force vector to get direction only and trim magnitude
            force.Normalize();
            Rigidbody2D pushRB = other.gameObject.GetComponent<Rigidbody2D>();
            pushRB.AddForce(-force * knockBackForce);
        }

        if (other.gameObject.tag == "Weapon")
        {
            EnemyLives -= 1;
            if (EnemyLives <= 0)
            {
                gameController
                    .GetComponent<GameController>()
                    .IncrementExterminatedBugs();

                Text bugsExterminatedTextObject =
                    bugsExterminatedText.GetComponent<Text>();
                bugsExterminatedTextObject.text =
                    "BUG EXTERMINATED: " +
                    gameController
                        .GetComponent<GameController>()
                        .bugsExterminated
                        .ToString();
                Destroy (gameObject);
            }
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isAttacking = false;
            //anim.SetBool("Attack", false);
        }
    }

    //DISPLAY the range of enemy's attack when selected in the Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    //     IEnumerator EndKnockBack(Rigidbody2D otherRB)
    //     {
    //         yield return new WaitForSeconds(0.2f);
    //         otherRB.velocity = new Vector3(0, 0, 0);
    //     }
}
