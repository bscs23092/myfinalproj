using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cont2 : MonoBehaviour
{
    public GameObject enemy;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemy, new Vector3(Random.Range(40, 900), Random.Range(30,60), 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
