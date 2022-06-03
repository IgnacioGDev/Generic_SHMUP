using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PwrUpShield : MonoBehaviour
{
    [SerializeField]
    private int _hitPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.Find("Player").transform.position;
        DestroyShield();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnCollisionEnter2D Shield");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _hitPoints--;
            Destroy(collision.gameObject);
        }
    }

    private void DestroyShield()
    {
        if (_hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
