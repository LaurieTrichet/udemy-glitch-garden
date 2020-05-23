using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range( 0.0f, 10.0f)] [SerializeField] float speed = 1;
    [SerializeField] int damage = 100;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void HandleCollision(GameObject other)
    {
        //if ( ! gameObject.CompareTag(other.tag))
        //{
        //    return;
        //}

        var health = other.GetComponent<HealthSystem>();
        if (health)
        {
            health.HandleHit(damage);
            Destroy(gameObject);
        }
    }
}
