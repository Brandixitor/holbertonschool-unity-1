using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Provides player controls.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1600f;
    public int health = 5;
    private int score = 0;

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game over!");
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    /// <summary>
    /// Computes physics calculations with player controls.
    /// </summary>
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(x, 0, z).normalized;
        Vector3 force = dir * speed * Time.deltaTime; 
        rb.AddForce(force);
    }

    /// <summary>
    /// Triggers when colliding with coins, traps, and goals.
    /// </summary>
    /// <param name="other">The collider that collided with the player.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log(string.Format("Score: {0}", score));
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log(string.Format("Health: {0}", health));
        }
        else if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }
}
