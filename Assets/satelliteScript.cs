using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SatelliteScript : MonoBehaviour
{
    int satelliteHealth;
    public GameObject explosion;
    public float destructionDelay = 5.0f; // Delay before destroying the satellite and loading the scene
    public GameObject flare1;
    public GameObject flare2;

    void Start()
    {
        satelliteHealth = 10;
    }

    void Update()
    {
        if (satelliteHealth <= 0)
        {
            StartCoroutine(HandleDestructionAndSceneLoad());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("222"))
        {
            satelliteHealth--;
        }
    }

    private IEnumerator HandleDestructionAndSceneLoad()
    {
        // Instantiate the explosion effect
        Instantiate(explosion, transform.position, transform.rotation);

        // Destroy flares
        if (flare1 != null) Destroy(flare1);
        if (flare2 != null) Destroy(flare2);

        // Wait for the specified destruction delay
        yield return new WaitForSeconds(destructionDelay);

        // Load the game win scene after the delay
        SceneManager.LoadScene("gameWin");

        // Finally, destroy the satellite
        Destroy(this.gameObject);
    }
}
