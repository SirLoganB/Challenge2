using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public Text countText;

    public Text winText;

    public Text livesText;

    private Rigidbody2D rb2d;

    public int count;

    private int lives;

    public GameObject target;

    public GameObject target1;

    public GameObject target2;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = "";
        countText.text = "Count: " + count.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();

            if (count == 4)
            {
                transform.position = new Vector3(2, -9, 40);
                lives = 3;
                livesText.text = "Lives: 3";
                target1.SetActive(false);
                target2.SetActive(true);
            }

        }

        else if (other.gameObject.CompareTag("RedEnemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetCountText();

            if (lives <= 0)
            {
                target.SetActive(false);
                Time.timeScale = 0f;
            }

        }

        void SetCountText()
        {
            countText.text = "Count: " + count.ToString();
            if (count >= 8)
            {
                winText.text = "You win! Game created by Logan Bernatt";
            }
            livesText.text = "Lives: " + lives.ToString();

            if (lives <= 0)
            {
                winText.text = "You Lose! :( Game created by Logan Bernatt";
            }

        }
    }
}