using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed;
    [SerializeField]
    GameObject _laser;
    [SerializeField]
    GameObject _chargedShot;
    [SerializeField]
    GameObject _middleShot;
    [SerializeField]
    Transform _shootPosition;

    float _horizontal;
    float _vertical;

    float _timeCounter = 0;
    [SerializeField]
    int _timeToShootChargedShot = 4;

    [SerializeField]
    int _timer;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 worldP = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10f));

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 4, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        MovementTransform();
        ShootLaser();
        WeaponCharge();
    }

    private void LateUpdate()
    {
        Boundaries();
    }

    //Sets the player's movement behavior
    private void MovementTransform()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(_horizontal, _vertical);

        transform.Translate(movement * _speed * Time.deltaTime);
    }

    //Spawns a simple laser
    private void ShootLaser()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(_laser, _shootPosition.position, Quaternion.identity);
        }
    }

    //Set player bounds in the screen
    private void Boundaries()
    {
        Vector2 playerBounds = transform.position;
        playerBounds.x = Mathf.Clamp(playerBounds.x, -8.5f, 8.5f);
        playerBounds.y = Mathf.Clamp(playerBounds.y, -4.6f, 4.6f);
        transform.position = playerBounds;
    }

    private void WeaponCharge()
    {
        if (Input.GetKey(KeyCode.C))
        {
            _timeCounter += Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            if (Mathf.RoundToInt(_timeCounter) >= _timeToShootChargedShot)
            {
                Instantiate(_chargedShot, _shootPosition.position, Quaternion.identity);
            }
            else if ((Mathf.RoundToInt(_timeCounter)) >= 2f && (Mathf.RoundToInt(_timeCounter) < _timeToShootChargedShot))
            {
                // Debug.Log("Time to middle shot: " + (Time.time - _timeCounter < _timeToShootMiddleShot));
                Instantiate(_middleShot, _shootPosition.position, Quaternion.identity);
            }
            _timeCounter = 0;
        }
    }

    public int GetTimeToChargeShot()
    {
        //return Mathf.RoundToInt(Time.time - _timeCounter);
        return Mathf.RoundToInt(_timeCounter);

    }

    //DEPRECATED ChargedShot method
    //private void ChargeShot()
    //{
    //    //Captures the current when a key is pressed (only during that frame) time and stores it in _timeCounter variable
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        _timeCounter = Mathf.RoundToInt(Time.time);
    //    }
    //    else if (Input.GetKeyUp(KeyCode.C))
    //    {
    //        //SPAWNS FULL CHARGED SHOT
    //        if ((Mathf.RoundToInt(Time.time - _timeCounter)) >= _timeToShootChargedShot)
    //        {
    //            //Debug.Log("Ready to shot!");
    //            Instantiate(_chargedShot, _shootPosition.position, Quaternion.identity);
    //        }
    //        //SPAWN MIDDLE SHOT
    //        else if ((Mathf.RoundToInt(Time.time - _timeCounter)) >= 1f && (Mathf.RoundToInt(Time.time - _timeCounter) < _timeToShootChargedShot))
    //        {
    //            // Debug.Log("Time to middle shot: " + (Time.time - _timeCounter < _timeToShootMiddleShot));
    //            Instantiate(_middleShot, _shootPosition.position, Quaternion.identity);
    //        }
    //        _timeCounter = 0;
    //    }
    //}

}
