using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeShot : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private int _damage = 3;
    [SerializeField]
    private int _hitPoints = 3;

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

        //ADDED TODAY 16/05
        if (collision.gameObject.CompareTag("Enemy"))
        {
            NormalEnemy enemy = collision.gameObject.GetComponent<NormalEnemy>();
            _hitPoints -= enemy.HitPoints;

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
