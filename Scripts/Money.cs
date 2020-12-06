using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public float Bcounter;
    public float BminTimeBetweenShots = 1f;
    public float BmaxTimeBetweenShots = 3f;
    public float Gcounter;
    public float GminTimeBetweenShots = 4f;
    public float GmaxTimeBetweenShots = 8f;
    public float Scounter;
    public float SminTimeBetweenShots = 3f;
    public float SmaxTimeBetweenShots = 6f;
    public GameObject money1;
    public GameObject money2;
    public GameObject money3;
    public static float xMin;
    public static float yMin;
    public static float xMax;
    public static float yMax;
    public static float padding = 1f;
    int Blife = 9;
    int Slife = 6;
    int Glife = 3;
    public List<GameObject> BronzeCoins = new List<GameObject>();
    public List<GameObject> SilverCoins = new List<GameObject>();
    public List<GameObject> GoldCoins = new List<GameObject>();
    int bronzeIndex;
    int silverIndex;
    int goldIndex;


    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries(); 
        Bcounter = Random.Range(BminTimeBetweenShots, BmaxTimeBetweenShots);
        Scounter = Random.Range(SminTimeBetweenShots, SmaxTimeBetweenShots);
        Gcounter = Random.Range(GminTimeBetweenShots, GmaxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        if(Count_Down.beginGame == true)
        {
            CountDownAndInstantiate();
        }
        
    }

    private void CountDownAndInstantiate()
    {
        Bcounter -= Time.deltaTime;
        if (Bcounter <= 0)
        {
            Bcounter = Random.Range(BminTimeBetweenShots, BmaxTimeBetweenShots);
            float gaming1 = UnityEngine.Random.Range(xMin, xMax);
            float gaming2 = UnityEngine.Random.Range(yMin, yMin);
            Vector2 moneyPos = new Vector2(gaming1, gaming2);
            GameObject bronzeInstance = Instantiate(money1, moneyPos, Quaternion.identity) as GameObject;
            BronzeCoins.Add(bronzeInstance);
            Destroy(BronzeCoins[bronzeIndex], Blife);
            bronzeIndex++;
        }
        Scounter -= Time.deltaTime;
        if (Scounter <= 0)
        {
            Scounter = Random.Range(SminTimeBetweenShots, SmaxTimeBetweenShots);
            float gaming1 = UnityEngine.Random.Range(xMin, xMax);
            float gaming2 = UnityEngine.Random.Range(yMin, yMax);
            Vector2 moneyPos = new Vector2(gaming1, gaming2);
            GameObject silverInstance = Instantiate(money2, moneyPos, Quaternion.identity) as GameObject;
            SilverCoins.Add(silverInstance);
            Destroy(SilverCoins[silverIndex], Slife);
            silverIndex++;
        }
        Gcounter -= Time.deltaTime;
        if (Gcounter <= 0)
        {
            Gcounter = Random.Range(GminTimeBetweenShots, GmaxTimeBetweenShots);
            float gaming1 = UnityEngine.Random.Range(xMin, xMax);
            float gaming2 = UnityEngine.Random.Range(yMin, yMax);
            Vector2 moneyPos = new Vector2(gaming1, gaming2);
            GameObject goldInstance = Instantiate(money3, moneyPos, Quaternion.identity) as GameObject;
            GoldCoins.Add(goldInstance);
            Destroy(GoldCoins[goldIndex], Glife);
            goldIndex++;
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
