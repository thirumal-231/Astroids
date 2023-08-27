using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public float bulletSpeed = 300.0f;
    public float lifeTimeBullet = 10.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ProjectBullets(Vector2 direction)
    {
        rb.AddForce(direction * this.bulletSpeed);

        Destroy(this.gameObject, this.lifeTimeBullet);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
