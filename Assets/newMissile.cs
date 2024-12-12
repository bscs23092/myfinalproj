using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newMissile : MonoBehaviour
{
    public GameObject explosion;
    controllerScript c;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("enemy") || collision.gameObject.name.StartsWith("alien"))
        {
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            sPlayer.score += 10;
            
        }
    }

}