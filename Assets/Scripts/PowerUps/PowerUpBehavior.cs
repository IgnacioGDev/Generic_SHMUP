using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private int _powerUpId;
    private int _randomIdMin = 2, _randomIdMax = 3;
    Rigidbody2D rb;
    [SerializeField]
    private Vector2 pos;
    [SerializeField]
    Vector2 lastVelocity;

    public int PowerUpId
    {
        get { return _powerUpId; }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetPowerUpId();

        rb = GetComponent<Rigidbody2D>();

        //rb.velocity = new Vector2(-1f,-1f) * _speed;
        rb.AddForce(new Vector2(20 * Time.deltaTime * _speed, 20 * Time.deltaTime * _speed));
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
        //BounceFromWall();
    }

    //Will determine which power up is going to be spawned/instantiated according to the id.
    //this id will be set choosing randomly between int values 0 to 4.
    public void SetPowerUpId()
    {
        _powerUpId = Random.Range(_randomIdMin, _randomIdMax);
        //Debug.Log("POWER UP ID IS: " + _powerUpId);
    }

    public void SpawnPowerUp(Transform enemyTransform)
    {
        int randomNum = Random.Range(0, 5);
        //Debug.Log("Random number is: " + randomNum);

        if (randomNum >= 0)
        {
            Instantiate(gameObject, enemyTransform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "StageCollider")
        {
            var speed = lastVelocity.magnitude;
            var reflectedPosition = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = reflectedPosition * speed;
        }
    }













    //REDO




    private void Movement()
    {

        transform.Translate(new Vector3(-1f, -1f) * _speed * Time.deltaTime);

    }

    private void BounceFromWall()
    {
        Vector2 screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10f));
        Debug.Log(screenSize.x);
        //Debug.Log(transform.position.x);
        if (transform.position.x <= screenSize.x)
        {
            //Vector2.Reflect(transform.position.x, transform.position.y);
            //Debug.Log("object testing yes");
        }
    }
}
