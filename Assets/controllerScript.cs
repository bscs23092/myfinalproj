using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controllerScript : MonoBehaviour
{
    public GameObject enemy;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemy, new Vector3(Random.Range(-80, 80), Random.Range(0, 40), 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
