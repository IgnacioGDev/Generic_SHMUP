using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    [SerializeField]
    float _speed;
    [SerializeField]
    float _magnitude;
    [SerializeField]
    float _vSpeed;
    [SerializeField]
    bool _isMovingRight;


    [SerializeField]
    bool _isAllowed = true;

    Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //VerticalMovement();
    }

    private void FixedUpdate()
    {
        // Movement();
        ExperimentalMovement();

    }

    [SerializeField]
    float counter = 0;

    void Movement()
    {
        var test = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        if (_isAllowed)
        {
            transform.position = new Vector2(Mathf.Sin(Time.time * _speed) * _magnitude, transform.position.y);
        }
        if (transform.position.x > test.x * 0.67 || transform.position.x < test.x * -0.67)
        {
            transform.position = transform.position;
            _isAllowed = false;
        }
        if (_isAllowed == false)
        {
            counter += Time.deltaTime;
            //Debug.Log(counter);
            //transform.Translate(Vector2.down * _vSpeed * Time.deltaTime);
            if (counter < 1)
            {
                transform.position = Vector2.Lerp(transform.position, (transform.position - new Vector3(0, 2)), _vSpeed * Time.deltaTime);
            }
            else
            {
                counter = 0;
                _isAllowed = true;
            }
        }
    }

    [SerializeField]
    bool isFacingRight = true;

    public float desiredDuration;
    private float elapsedTime;
    Vector2 newPosition;
    public float verticalDesiredDuration;
    private float verticalElapsedTime;


    void ExperimentalMovement()
    {
        var test = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Debug.Log(test.x * 0.64);

        float percentageComplete = elapsedTime / desiredDuration;
        float verticalPercComplete = verticalElapsedTime / verticalDesiredDuration;

        if (_isAllowed)
        {
            newPosition = transform.position;
            elapsedTime += Time.deltaTime;
            verticalElapsedTime = 0;

            if (isFacingRight)
            {
                transform.position = Vector2.Lerp(new Vector2(startPosition.x, transform.position.y), new Vector2(test.x * 0.615f, transform.position.y), Mathf.SmoothStep(0,1,percentageComplete));

                //transform.position = Vector2.Lerp(transform.position, new Vector2(test.x * 0.65f, transform.position.y), _speed * Time.deltaTime);
                //transform.Translate(Vector2.right * _speed * Time.deltaTime);
            }
            if (!isFacingRight)
            {
                transform.position = Vector2.Lerp(new Vector2(-startPosition.x, transform.position.y), new Vector2(test.x * -0.615f, transform.position.y), Mathf.SmoothStep(0, 1, percentageComplete));

                //transform.position = Vector2.Lerp(transform.position, new Vector2(test.x * -0.65f, transform.position.y), _speed * Time.deltaTime);
                //transform.Translate(Vector2.left * _speed * Time.deltaTime);
            }
        }
        if (transform.position.x > test.x * 0.615 || transform.position.x < test.x * -0.615)
        {
            _isAllowed = false;
        }
        if (_isAllowed == false)
        {
            

            verticalElapsedTime += Time.deltaTime;

            counter += Time.deltaTime;
            //Debug.Log(counter);
            //transform.Translate(Vector2.down * _vSpeed * Time.deltaTime);
            if (counter < verticalDesiredDuration)
            {
                //transform.position = Vector2.Lerp(transform.position, (transform.position - new Vector3(0, 2)), _vSpeed * Time.deltaTime);
                //transform.Translate(Vector2.down * _vSpeed * Time.deltaTime);
                transform.position = Vector2.Lerp(new Vector2(transform.position.x, newPosition.y), new Vector2(transform.position.x, newPosition.y - 2f), Mathf.SmoothStep(0,1,verticalPercComplete));

            }
            else
            {
                _isAllowed = true;
                counter = 0;
                isFacingRight = !isFacingRight;
            }
            elapsedTime = 0;
        }

    }

    void VerticalMovement()
    {
        transform.Translate(Vector2.down * _vSpeed * Time.deltaTime);
    }

    void ScreenToWorldPoints()
    {
        var test = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
}
