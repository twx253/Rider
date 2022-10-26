using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody2D rig;
    public bool move;
    public bool on_ground;
    public float speed;
    public float rotate_speed = 2f;
    public float forcedown;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            move = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            move = false;
        }
    }

    private void FixedUpdate()
    {
        if (on_ground)
        {
            if (move)
            {
                rig.AddForce(transform.right * speed * Time.fixedDeltaTime * 100f, ForceMode2D.Force);
            }
            rig.AddForce(-transform.up * forcedown * speed);
        }
        else
        {
            if (move)
            {
                rig.AddTorque(rotate_speed *Time.fixedDeltaTime * 100, ForceMode2D.Force);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Line"))
        {
            on_ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Line"))
        {
            on_ground = false;
        }
    }
}
