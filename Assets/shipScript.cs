using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class shipScript : MonoBehaviour
{
    public Text scrTxt, hlthTxt;
    public GameObject missile;

    public float delay = 1f;
    static public int score;
    static public int health;

    // Action booleans
    public bool canMoveForward;
    public bool canMoveBackward;
    public bool canRotateLeft;
    public bool canRotateRight;
    public bool canFireMissile;
    public bool canMoveUp;
    public bool canMoveDown;
    public bool canMoveRight;
    public bool canMoveLeft;

    void Start()
    {
        score = 0;
        health = 100;
    }

    void Update()
    {
        // Forward movement
        if ((Input.GetKey(KeyCode.Space) || canMoveForward))
        {
            transform.Translate(0, 0, 0.25f);
        }

        // Rotate left
        if ((Input.GetKey(KeyCode.A) || canRotateLeft))
        {
            transform.Rotate(0, -1f, 0);
        }

        // Rotate right
        if ((Input.GetKey(KeyCode.D) || canRotateRight))
        {
            transform.Rotate(0, 1f, 0);
        }

        // Backward movement
        if ((Input.GetKey(KeyCode.Z) || canMoveBackward))
        {
            transform.Translate(0, 0, -0.25f);
        }

        // Move up
        if ((Input.GetKey(KeyCode.UpArrow) || canMoveUp) && transform.position.y < 100)
        {
            transform.Translate(0, 0.2f, 0);
        }

        // Move down
        if ((Input.GetKey(KeyCode.DownArrow) || canMoveDown) && transform.position.y > -2)
        {
            transform.Translate(0, -0.2f, 0);
        }

        // Move right
        if ((Input.GetKey(KeyCode.RightArrow) || canMoveRight))
        {
            transform.Translate(0.2f, 0, 0);
        }

        // Move left
        if ((Input.GetKey(KeyCode.LeftArrow) || canMoveLeft))
        {
            transform.Translate(-0.2f, 0, 0);
        }

        // Fire missile
        if ((Input.GetKeyDown(KeyCode.W) || canFireMissile))
        {
            Vector3 temp = transform.position;
            Instantiate(missile, temp, transform.rotation);
        }

        // Wrap around when reaching z = 150
        if (transform.position.z >= 150)
        {
            Vector3 temp = transform.position;
            temp.z = -60;
            transform.position = temp;
        }

        // Update UI
        hlthTxt.text = "Galaxtar's Health: " + health;
        scrTxt.text = "Galaxtar's Score: " + score;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("planet") || collision.gameObject.name.StartsWith("enemy"))
        {
            health -= 20;
            if (health <= 0)
            {
                SceneManager.LoadScene("gameOver");
            }
        }
    }

    private void FixedUpdate()
    {
        print("score: " + score);
        print("health: " + health);
    }

    // Specific functions to enable each action
    public void EnableMoveForward()
    {
        canMoveForward = true;
    }

    public void EnableMoveBackward()
    {
        canMoveBackward = true;
    }

    public void EnableRotateLeft()
    {
        canRotateLeft = true;
    }

    public void EnableRotateRight()
    {
        canRotateRight = true;
    }

    public void EnableFireMissile()
    {
        canFireMissile = true;
    }

    public void EnableMoveUp()
    {
        canMoveUp = true;
    }

    public void EnableMoveDown()
    {
        canMoveDown = true;
    }

    public void EnableMoveRight()
    {
        canMoveRight = true;
    }

    public void EnableMoveLeft()
    {
        canMoveLeft = true;
    }

    // Pause individual actions
    public void PauseMoveForward()
    {
        canMoveForward = false;
    }

    public void PauseMoveBackward()
    {
        canMoveBackward = false;
    }

    public void PauseRotateLeft()
    {
        canRotateLeft = false;
    }

    public void PauseRotateRight()
    {
        canRotateRight = false;
    }

    public void PauseFireMissile()
    {
        canFireMissile = false;
    }

    public void PauseMoveUp()
    {
        canMoveUp = false;
    }

    public void PauseMoveDown()
    {
        canMoveDown = false;
    }

    public void PauseMoveRight()
    {
        canMoveRight = false;
    }

    public void PauseMoveLeft()
    {
        canMoveLeft = false;
    }
}
