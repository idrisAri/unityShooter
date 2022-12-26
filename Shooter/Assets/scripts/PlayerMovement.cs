using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public float playerSpeed;

    private Vector3 touchPosition;
    public Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed = 10f;

    private float width;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // if (Application.platform == RuntimePlatform.WindowsEditor)
        //{

        //    touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    touchPosition.z = 0;
       //     direction = (touchPosition - transform.position);
        //    rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
       // }
       // else if (Application.platform == RuntimePlatform.Android)
       // {
       //     Touch touch = Input.GetTouch(0);
       //     touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
       //     touchPosition.z = 0;
       //     direction = (touchPosition - transform.position);
       //     rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
//
         //   if (touch.phase == TouchPhase.Ended)
        //    {
        //        rb.velocity = Vector2.zero;
        //    }
       // }

        if (joystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(joystick.joystickVec.x * playerSpeed, joystick.joystickVec.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        Vector3 camBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float x = Mathf.Clamp(transform.position.x, -camBounds.x + (width * 0.5F),camBounds.x - (width * 0.5F));

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
