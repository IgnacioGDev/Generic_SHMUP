using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    // Start is called before the first frame update
    float numero;
    void Start()
    {
        StartCoroutine(SpawnEnemyCorroutine());
    }

    void Update()
    {
        //ExperimetoInputsTimeDeltaTime();

        if (!PlayerState.Instance.GetPlayerState())
        {
            StopCoroutine(SpawnEnemyCorroutine());
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, new Vector2(Random.Range(-8.5f, 8.5f), 6), Quaternion.identity);
    }

    IEnumerator SpawnEnemyCorroutine()
    {
        while (!PlayerState.Instance.GetPlayerState())
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        }
    }

    //Method to test out Time.deltaTime instead Time.time for time counting
    private void ExperimetoInputsTimeDeltaTime()
    {
        if (Input.GetKey(KeyCode.S))
        {

            //Debug.Log(numero);

            numero += Time.deltaTime;
            Debug.Log(Mathf.RoundToInt(numero));

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            numero = 0;
        }

    }
}
