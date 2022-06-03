using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleShot : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private int _hitPoints;
    

    // Update is called once per frame
    void Update()
    {
        Movement();
        OutOfBounds();
    }

    private void Movement()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void OutOfBounds()
    {
        Vector2 position = Camera.main.WorldToScreenPoint(transform.position);
        if (position.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable hit = collision.gameObject.GetComponent<IDamageable>();

        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyKamikaze enemy = collision.GetComponent<EnemyKamikaze>();
            _hitPoints -= enemy.GetHitPoints();
            if (_hitPoints <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (hit != null)
        {
            hit.Damage(_damage);
        }
    }
}
