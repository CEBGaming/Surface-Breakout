using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BouncyBall1 : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxV = 15f;

    public Rigidbody2D rb;
    public GameObject pad;

    public int score = 0;
    public int lives = 3;
    public int brickCount = 0;

    public TextMeshProUGUI scoreTxt;
    public GameObject[] LivesImage;

    public AudioSource audioSourceHit;
    public AudioSource audioSourceGameOver;
    public AudioSource audioSourceLev;
    public AudioSource audioSourcePlop;

    //public GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        brickCount = FindObjectOfType<LevelGen>().transform.childCount;
        rb.velocity = Vector2.down * 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float movex = Input.GetAxis("Mouse X");
        pad.transform.Translate(movex,0, 0);

        if (transform.position.y < minY)
        {

            //audioSourcePlop.Play();
            if (lives <= 0)
            {
                //audioSourceGameOver.Play();
                //Invoke("GameOver", 4);
                GameOver();
            }

            else
            {
                transform.position = Vector3.zero;
                pad.transform.position = new Vector3(0, -4, 0);
                lives--;
                LivesImage[lives].SetActive(false);
                rb.velocity = Vector3.zero;
                rb.velocity = Vector2.down * 5f;

            }

        }

        if (rb.velocity.magnitude > maxV)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxV);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bricks"))
        {
            audioSourceHit.Play();
            audioSourcePlop.Play();
            //collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            score += 10;
            scoreTxt.text = score.ToString("0000");
            brickCount--;

            if (brickCount <= 0)
            {
                audioSourceLev.Play();
                rb.velocity = Vector3.zero;
                Invoke("LevelUp", 4);
                //SceneManager.LoadScene("LevelTwo");
            }
        }
    }

    void LevelUp()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");

    }
}

