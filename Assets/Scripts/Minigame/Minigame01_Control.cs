using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Minigame01_Control : MonoBehaviour
{
    //game section timer
    float timer = 32f;
    public TMP_Text T_timer;
    public TMP_Text T_water;

    public GameObject Water_Prefab;
    public GameObject player;

    public GameObject UI;

    float timeUntilNextWater = 0f;

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

        T_water.text = Game.Control.Score_water.ToString();

        timeUntilNextWater += Time.deltaTime + Game.Control.Score_water / 10f * Time.deltaTime;
        if (timeUntilNextWater > 2f && canSpawn)
        {
            timeUntilNextWater = 0f;
            Instantiate(Water_Prefab,
                        new Vector3(Random.Range(-6.4f, 6.4f), 4.6f),
                        Quaternion.identity,this.transform);
            if (Random.Range(0f, 2f) > 1.3f) {
                Instantiate(Water_Prefab,
                            new Vector3(Random.Range(-6.4f, 6.4f), 4.6f),
                            Quaternion.identity, this.transform);
            }
        }

    }

    private void OnEnable()
    {
        StartCoroutine(endMinigame());
        //Game.Control.canControl = true;
        timer = 31f;
        timeUntilNextWater = -2f;
        player.transform.position = new Vector2(0, -2);
    }

    private void OnDisable()
    {
        Game.Control.canControl = false;
        Game.Control.startNext();
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

        GameObject[] tempObjs = GameObject.FindGameObjectsWithTag("Pickup_water");
        foreach(GameObject tempObj in tempObjs) { Destroy(tempObj.gameObject); }

        Game.Control.canControl = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        UI.SetActive(false);

        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
