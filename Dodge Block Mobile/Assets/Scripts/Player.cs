using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

    public float speed = 18f;
    public float width = 5f;
    public int powerUps = 3;
    private int i = 0;
    public bool slowed;

    private Rigidbody2D rb;
    private GameManager gm;
    public GameObject[] slowdown;
    public GameObject particleShower;
    private Vector2 particlePos;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gm.PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Space) && slowed != true)
        {
            UseSlowdown();
        }
    }

    public void UseSlowdown()
    {
        if (powerUps <= 0)
        {
            powerUps = 0;
        }
        else if (powerUps > 0)
        {
            StartCoroutine(PowerUp());
        }
        powerUps -= 1;
        slowdown[i].SetActive(false);
        i += 1;
    }

	void FixedUpdate () {
        float x = Input.acceleration.x * Time.fixedDeltaTime * speed;
        Vector2 newPos = rb.position + Vector2.right * x;
        newPos.x = Mathf.Clamp(newPos.x, -width, width);
        rb.MovePosition(newPos);
	}

    void OnCollisionEnter2D (Collision2D coll)
    {
        FindObjectOfType<GameManager>().SaveScore(Time.timeSinceLevelLoad, PlayerPrefs.GetFloat("HighScore"));
        float x = (rb.transform.position.x + coll.transform.position.x)/2f;
        particlePos = new Vector2(x, rb.transform.position.y);
        Instantiate(particleShower, particlePos, Quaternion.identity);
        FindObjectOfType<GameManager>().EndGame();
    }

    IEnumerator PowerUp()
    {
        float slowness = 5f;
        Time.timeScale = 1f/slowness;
        speed = speed * slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        slowed = true;

        yield return new WaitForSeconds(3f / slowness);

        Time.timeScale = 1f;
        speed = 15f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        slowed = false;
    }

}
