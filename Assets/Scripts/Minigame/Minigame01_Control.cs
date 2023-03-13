using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Minigame01_Control : MonoBehaviour
{
    //game section timer
    float timer = 30f;
    public TMP_Text T_timer;
    public TMP_Text T_water;

    public GameObject Water_Prefab;

    float timeUntilNextWater = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(endMinigame());
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        T_timer.text = "Time:" + (timer).ToString("0");

        T_water.text = Game.Control.Score_water.ToString();

        timeUntilNextWater += Time.deltaTime + Game.Control.Score_water / 10f * Time.deltaTime;
        if (timeUntilNextWater > 2f)
        {
            timeUntilNextWater = 0f;
            Instantiate(Water_Prefab,
                        new Vector3(Random.Range(-3.3f, 3.3f), 3.3f),
                        Quaternion.identity,this.transform);
        }

    }

    private void OnEnable()
    {
        Game.Control.canControl = true;
    }

    private void OnDisable()
    {
        Game.Control.canControl = false;
        Game.Control.startNext();
    }

    IEnumerator endMinigame()
    {
        yield return new WaitForSeconds(30);
        gameObject.SetActive(false);
    }
}
