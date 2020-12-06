using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float deltaX;
    float deltaY;
    float newXPos;
    float newYPos;
    public static float xMin;
    public static float yMin;
    public static float xMax;
    public static float yMax;
    public static int points;
    [SerializeField] float movementSpeed = 2f;
    float padding = .5f;
    public static bool gameWon;
    public static bool gameLost;
    public AudioClip coinAudio;
    public static float coinAudioVolume = .4f;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        if(Count_Down.beginGame == true)
        {
            MovePlayer();
            RotatePlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bronze")
        {
            points++;
        }
        if (collision.tag == "silver")
        {
            points += 2;
        }
        if (collision.tag == "gold")
        {
            points += 3;
        }
        if(points >= 50)
        {
            gameWon = true;
            SceneManager.LoadScene("YOU_LOST");
            Count_Down.beginGame = false;
        }
        AudioSource.PlayClipAtPoint(coinAudio, Camera.main.transform.position, coinAudioVolume);
        Destroy(collision.gameObject);
    }

    private void MovePlayer()
    {
        deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void RotatePlayer()
    {
        if (deltaX != 0)
        {
            float angle = Mathf.Atan2(deltaX, deltaY) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if (deltaY != 0)
        {
            float angle = Mathf.Atan2(deltaX, -deltaY) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
