using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Bullet BulletPrefab;

    private bool thrusting;
    private float turnDirection;

    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;


    private Rigidbody2D rb;


    private void Awake()
    {
    // for intialisations
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1.0f;
        } else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1.0f;
        } else
        {
            turnDirection = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
    // for physics related updates
        if(thrusting)
        {
            rb.AddForce(this.transform.up * this.thrustSpeed);
        }
        if(turnDirection != 0.0f)
        {
            rb.AddTorque(turnDirection * this.turnSpeed);
        }

    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.BulletPrefab, this.transform.position, this.transform.rotation);
        bullet.ProjectBullets(this.transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().PlayerDied();
        }

    }
}
