using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingControl : MonoBehaviour
{

    public GameObject logo1, logo2, text1, text2;
    Animator aniL1, aniL2, aniT1, aniT2;
    public TMP_Text t1, t2;

    bool canQuit = false;

    void Start()
    {
    }

    private void OnEnable()
    {
        aniL1 = logo1.GetComponent<Animator>();
        aniL2 = logo2.GetComponent<Animator>();
        aniT1 = text1.GetComponent<Animator>();
        aniT2 = text2.GetComponent<Animator>();

        StartCoroutine(StartAnim());
    }

    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(1);

        aniL1.SetTrigger("0to100");
        aniL2.SetTrigger("0to100");
        yield return new WaitForSeconds(1);

        t1.text = "THE END";
        aniT1.SetTrigger("0to100");
        yield return new WaitForSeconds(1);

        yield return new WaitForSeconds(2);

        aniT1.SetTrigger("100to0");
        yield return new WaitForSeconds(1);
        t1.text = "A game by";
        aniT1.SetTrigger("0to100");
        yield return new WaitForSeconds(1);

        t2.text = "ZIDUAN ZHANG";
        aniT2.SetTrigger("0to100");
        yield return new WaitForSeconds(1.5f);
        aniT2.SetTrigger("100to0");
        yield return new WaitForSeconds(1);

        t2.text = "ZITENG ZHAO";
        aniT2.SetTrigger("0to100");
        yield return new WaitForSeconds(1.5f);
        aniT2.SetTrigger("100to0");
        yield return new WaitForSeconds(1);

        t2.text = "YICHEN LIN";
        aniT2.SetTrigger("0to100");
        yield return new WaitForSeconds(1.5f);
        aniT2.SetTrigger("100to0");
        yield return new WaitForSeconds(1);

        t2.text = "JINGYI FENG";
        aniT2.SetTrigger("0to100");
        yield return new WaitForSeconds(1.5f);
        aniT2.SetTrigger("100to0");
        yield return new WaitForSeconds(1);

        t2.text = "YEE CHENG";
        aniT2.SetTrigger("0to100");
        yield return new WaitForSeconds(1.5f);
        aniT2.SetTrigger("100to0");
        yield return new WaitForSeconds(1);

        t2.text = "JEFFREY ZHONG";
        aniT2.SetTrigger("0to100");
        yield return new WaitForSeconds(1.5f);
        aniT2.SetTrigger("100to0");

        aniT1.SetTrigger("100to0");
        yield return new WaitForSeconds(1);

        t1.text = "Your Game Data:";
        aniT1.SetTrigger("0to100");
        yield return new WaitForSeconds(1);
        t2.text = "Water: " + Game.Control.Score_water +
                  " Sunshine: " + Game.Control.Score_nutrition.ToString("0") +
                  " Health: " + Game.Control.Score_health;
        aniT2.SetTrigger("0to100");
        yield return new WaitForSeconds(2);

        aniT1.SetTrigger("100to0");
        aniT2.SetTrigger("100to0");
        yield return new WaitForSeconds(1);

        t1.text = "Thank you for playing!";
        aniT1.SetTrigger("0to100");
        yield return new WaitForSeconds(1);
        t2.text = "Press anykey to quit.";
        canQuit = true;
        aniT2.SetTrigger("0to100");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && canQuit)
        {
            Application.Quit();
        }
    }

}
