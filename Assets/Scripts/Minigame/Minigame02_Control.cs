using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Minigame02_Control : MonoBehaviour
{
    //game section timer
    float timer = 32f;
    public TMP_Text T_timer;
    public TMP_Text T_score;

    public GameObject platform_Prefab_L;
    public GameObject platform_Prefab_R;

    public GameObject player;
    public GameObject spotLight;
    public GameObject UI;

    float timeUntilNextplatform = 0f;

    bool canSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(endMinigame());
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        T_timer.text = (timer).ToString("0");
        T_score.text = Game.Control.Score_nutrition.ToString("0");

        if (!Physics2D.Linecast(player.transform.position,spotLight.transform.position, 1 << 3)) {
            Game.Control.Score_nutrition += Time.deltaTime;
        }
        //Debug.DrawLine(player.transform.position, spotLight.transform.position);

        timeUntilNextplatform += Time.deltaTime + Game.Control.Score_nutrition / 40f * Time.deltaTime;
        float temp = 2.0f;
        if (timeUntilNextplatform > temp && canSpawn)
        {
            timeUntilNextplatform = 0f;
            temp = Random.Range(2f, 4f);
            Instantiate(platform_Prefab_R,
                        new Vector3(10.8f, Random.Range(1f,2f)),
                        Quaternion.identity, this.transform);
            if (Random.Range(0f, 2f) > 1.5f)
            {
                Instantiate(platform_Prefab_L,
                            new Vector3(-10.8f, 3f),
                            Quaternion.identity, this.transform);
            }
        }

    }

    private void OnEnable()
    {
        StartCoroutine(endMinigame());
        //Game.Control.canControl = true;
        //Game.Control.GlobalLight.intensity = 0.5f;
        timer = 31f;
        timeUntilNextplatform = -2f;
        player.transform.position = new Vector2(0, -2);
    }

    private void OnDisable()
    {
        Game.Control.canControl = false;
        Game.Control.startNext();
        //Game.Control.GlobalLight.intensity = 1f;
    }

    IEnumerator endMinigame()
    {
        Game.Control.blackout();

        yield return new WaitForSeconds(1);
        UI.SetActive(true);
        Game.Control.canControl = true;
        canSpawn = true;

        yield return new WaitForSeconds(30);
        Game.Control.blackin();
        canSpawn = false;

        GameObject[] tempObjs = GameObject.FindGameObjectsWithTag("platform");
        foreach (GameObject tempObj in tempObjs) { Destroy(tempObj.gameObject); }

        Game.Control.canControl = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        UI.SetActive(false);

        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
