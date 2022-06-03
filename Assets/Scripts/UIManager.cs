using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _hitPointsUIText;
    [SerializeField]
    private Text _lifeCounterUIText;
    [SerializeField]
    private Text _timeToChargeShot;
    // Start is called before the first frame update
    [SerializeField]
    GameObject player;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _hitPointsUIText.text = "Health: " + PlayerState.Instance.GetPlayerHitPoints().ToString();
        _lifeCounterUIText.text = "Lives: " + PlayerState.Instance.GetPlayerExtraLives().ToString();

        //condition that makes sure that the counter variable will only display until number 4 -- NEEDS TO BE REFACTORIZED
        if (Input.GetKey(KeyCode.C) && player.GetComponent<PlayerController>().GetTimeToChargeShot() <=4)
        {
            _timeToChargeShot.text = "Charge: " + player.GetComponent<PlayerController>().GetTimeToChargeShot();
        }
        //once the button c is released, counter display is back to 0
        else if(Input.GetKeyUp(KeyCode.C))
        {
            _timeToChargeShot.text = "Charge: 0";
        }
    }
}
