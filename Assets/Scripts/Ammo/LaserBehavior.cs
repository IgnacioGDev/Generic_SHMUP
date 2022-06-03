using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    [SerializeField]
    float _speed;
    float _laserMovement = 1f;
    int _damage = 1;


    // Update is called once per frame
    void Update()
    {
        LaserMovement();
        OutOfBounds();
    }

    private void LaserMovement()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void OutOfBounds()
    {
        Vector2 laserPos = Camera.main.WorldToScreenPoint(transform.position);
        if (laserPos.y > Screen.width)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable hit = collision.GetComponent<IDamageable>();

        if (hit != null)
        {
            hit.Damage(_damage);
            Destroy(gameObject);
        }
    }


}

