using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Minigame03_Control : MonoBehaviour
{
    //game section timer
    float timer = 32f;
    public TMP_Text T_timer;
    public TMP_Text T_health;

    public GameObject bugs_Prefab;
    public GameObject player;

    public GameObject UI;

    float timeUntilNextBug = 0f;

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

        T_health.text = Game.Control.Score_health.ToString();

        timeUntilNextBug += Time.deltaTime + Game.Control.Score_health / 50f * Time.deltaTime;
        if (timeUntilNextBug > 2f)
        {
            timeUntilNextBug = 0f;
            var tempR = Random.Range(0, 3);
            switch (tempR)
            {
                case 0:
                    Instantiate(bugs_Prefab,
                        new Vector3(Random.Range(-9f, 9f), 4.75f),
                        Quaternion.identity, this.transform);
                    break;
                case 1:
                    Instantiate(bugs_Prefab,
                        new Vector3(Random.Range(-9f, 9f), -4.75f),
                        Quaternion.identity, this.transform);
                    break;
                case 2:
                    Instantiate(bugs_Prefab,
                        new Vector3(-9f, Random.Range(-4.75f, 4.75f)),
                        Quaternion.identity, this.transform);
                    break;
                case 3:
                    Instantiate(bugs_Prefab,
                        new Vector3(9f, Random.Range(-4.75f, 4.75f)),
                        Quaternion.identity, this.transform);
                    break;
            }
            
        }

    }

    private void OnEnable()
    {
        StartCoroutine(endMinigame());
        //Game.Control.canControl = true;
        timer = 31f;
        timeUntilNextBug = -2f;
        player.transform.position = new Vector2(0, 0);
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

        yield return new WaitForSeconds(30);
        Game.Control.blackin();
        Game.Control.canControl = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        UI.SetActive(false);

        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
