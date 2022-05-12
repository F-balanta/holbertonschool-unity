using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(0, 0, 2000 * Time.deltaTime);
        score = 0;
        health = 5;
        scene =  SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            //Debug.Log("Game Over!");
            WinLoseImage.gameObject.SetActive(true);
            WinLoseText.text = "Game Over!";
            WinLoseText.color = Color.white;
            WinLoseImage.color = Color.red;
            StartCoroutine(LoadScene(3));
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            rb.AddForce(1000 * Time.deltaTime * speed, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-1000 * Time.deltaTime * speed, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, 1000 * Time.deltaTime * speed);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -1000 * Time.deltaTime * speed);
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            //Debug.Log("Score: " + score);
            SetScoreText();
        }
        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            //Debug.Log("Health: " + health);
            SetHealthText();
        }
        if (other.gameObject.tag == "Goal")
        {
            //Debug.Log("You win!");
            WinLoseImage.gameObject.SetActive(true);
            WinLoseText.text = "You Win";
            WinLoseText.color = Color.black;
            WinLoseImage.color = Color.green;
            StartCoroutine(LoadScene(3));
        }
    }
    public Rigidbody rb;
    public float speed;
    private int score;
    public int health;
    private Scene scene;
    public Text scoreText;
    public Text healthText;
    public Text WinLoseText;
    public Image WinLoseImage;
}
