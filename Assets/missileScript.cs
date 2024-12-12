using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissileScript : MonoBehaviour
{
    public GameObject explosion;
    controllerScript c;

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(0, 0, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("enemy") || collision.gameObject.name.StartsWith("alien"))
        {
            // Destroy the enemy object
            Destroy(collision.gameObject);

            // Instantiate the explosion effect
            Instantiate(explosion, transform.position, transform.rotation);

            // Increment the score
            shipScript.score += 10;

            // Check if the score reaches the threshold
            if (shipScript.score >= 50)
            {
                StartCoroutine(LoadFinalSceneAfterDelay(2.0f)); // Wait for 2 seconds
            }
        }
    }

    private IEnumerator LoadFinalSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        SceneManager.LoadScene("FinalScene"); // Load the final scene
    }
}
