using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*private Vector3 touchPosition;
    private Vector3 direction;
    private Rigidbody body;
    [Space]
    [SerializeField]
    private float speed = 1f;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
            /*
             * Camera.main.ScreenToWorldPoint(position);
             * position: A screen space position (often mouse x, y), 
             * plus a z position for depth (for example, a camera clipping plane).
             */
    //touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
    //touchPosition.y = 0;
    /*direction = touchPosition - transform.position;
    body.velocity = new Vector3(direction.x, 0f, direction.z) * speed;
    body.rotation = Quaternion.LookRotation(body.velocity);

    //TouchPhase is an enum type that contains the states of possible finger touches.

}
}*/
    [Space]
    [SerializeField]
    private float speed = 1f;

    Vector3 firstTouchPos = Vector3.zero;
    Vector3 deltaTouchPos = Vector3.zero;
    Vector3 direction = Vector3.zero;

    Rigidbody body;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Detects clicks
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPos = Input.mousePosition;
        }

        // true if  mouse button is held down
        if (Input.GetMouseButton(0))
        {
            deltaTouchPos = Input.mousePosition - firstTouchPos;
            direction = new Vector3(deltaTouchPos.x, 0f, deltaTouchPos.y);

            body.velocity = direction.normalized * speed;
            if(body.velocity != Vector3.zero)
            {
                body.rotation = Quaternion.LookRotation(body.velocity);
            }
            
        }
        else
        {
            body.velocity = Vector3.zero;
        }
    }
}
