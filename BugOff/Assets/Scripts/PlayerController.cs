using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Camera cam;

    public Vector2 movement;

    public Vector2 mousePos;

    void Awake()
    {
        //assign rigidbody2D and camera to variables
        rb = GetComponent<Rigidbody2D>();
        cam =
            GameObject
                .FindGameObjectWithTag("MainCamera")
                .GetComponent<Camera>() as
            Camera;
    }

    void Update()
    {
        if (gameObject != null)
        {
            //for position, get axis inputs
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            //for rotation: get mouse position
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void FixedUpdate()
    {
        //actual movement uses Rigidbody, so goes in FixedUpdate
        rb
            .MovePosition(rb.position +
            movement * moveSpeed * Time.fixedDeltaTime);

        //actual rotation uses vector math to calculate angle, then rotates character to mouse
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
