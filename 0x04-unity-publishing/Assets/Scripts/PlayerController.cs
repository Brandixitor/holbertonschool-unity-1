using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    public Text scoreText;
    public Text healthText;
    public Image winLoseBG;
    public Text winLoseText;

    void Update()
    {
        if (health == 0)
        {
            winLoseText.text = "Game Over!";
            winLoseText.color = Color.white;
            winLoseBG.color = Color.red;
            winLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
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
    /// Updates the ScoreText with the player's current score.
    /// </summary>
    void SetScoreText()
    {
        scoreText.text = string.Format("Score: {0}", score);
    }

    /// <summary>
    /// Updates the HealthText with the player's health score.
    /// </summary>
    void SetHealthText()
    {
        healthText.text = string.Format("Health: {0}", health);
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            SetScoreText();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }
        else if (other.CompareTag("Goal"))
        {
            winLoseText.text = "You Win!";
            winLoseText.color = Color.black;
            winLoseBG.color = Color.green;
            winLoseBG.gameObject.SetActive(true);
        }
    }
}
