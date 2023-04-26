using System.Collections;
using System.Collections.Generic;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using TMPro;

public class Game : MonoBehaviour
{
    public static Game Control;

    [Header("FlowControl")]
    public string currentStatus = "undefine";

    [Header("PlayerStatus")]
    public int Score_water = 0;
    public int Score_health = 100;
    public float Score_nutrition = 0;

    [Header("DialogSys")]
    public GameObject dialogSys;
    public int savedAnswer = -1;

    [Header("GameSys")]
    public bool canControl = false;
    public GameObject gameSys_01;
    public GameObject gameSys_02;
    public GameObject gameSys_03;

    [Header("GameObject")]
    public Light2D GlobalLight;
    public GameObject background;
    public Sprite[] backgroundSprite = new Sprite[9];
    public GameObject blackScreen;
    public GameObject oldPotato;
    public Sprite oldoldPotato;
    public GameObject oldPotatoDialog;
    public Sprite oldoldPotatoDialog;


    private void Awake()
    {
        Control = this;
    }

    private void Start()
    {
        startDialog("0-1");

        //test
        //startDialog("2-2");
        //startGame("1-1-2G", 2);
    }

    public void startDialog(string status)
    {
        currentStatus = status;
        dialogSys.SetActive(true);
    }

    public void startGame(string status,int gameNum)
    {
        currentStatus = status;
        switch (gameNum)
        {
            case 1:
                gameSys_01.SetActive(true);
                break;
            case 2:
                gameSys_02.SetActive(true);
                break;
            case 3:
                gameSys_03.SetActive(true);
                break;

            default:
                Debug.Log("ERROR_gameSys_Number_Undefine");
                break;
        }
        
    }

    public void startNext()
    {
        StartCoroutine(startNext_C());
    }

    IEnumerator startNext_C()
    {
        yield return new WaitForSeconds(0.1f);

        switch (currentStatus)
        {
            case "0-1":
                startDialog("1-1");
                break;
            case "1-1":
                startGame("1-1G",1);
                break;
            case "1-1G":
                startDialog("1-1-2");
                break;
            case "1-1-2":
                startGame("1-1-2G", 2);
                break;
            case "1-1-2G":
                startDialog("1-2");
                break;
            case "1-2":
                startDialog("1-3-1");
                break;
            case "1-3-1":
                startGame("1-3-1G", 1);
                break;
            case "1-3-1G":
                startDialog("1-3-2");
                break;
            case "1-3-2":
                startGame("1-3-2G", 2);
                break;
            case "1-3-2G":
                startDialog("1-3-3");
                break;
            case "1-3-3":
                startGame("1-3-3G", 1);
                break;
            case "1-3-3G":
                startDialog("2-1");
                break;
            case "2-1":
                startGame("2-1G", 3);
                break;
            case "2-1G":
                startDialog("2-2");
                break;
            case "2-2":
                if (savedAnswer == 1)
                {
                    startDialog("2-3-A");
                }
                else
                {
                    startDialog("2-3-B");
                }
                break;
            case "2-3-A":
            case "2-3-B":
                startDialog("2-4-1");
                break;
            case "2-4-1":
                startGame("2-4-1G", 2);
                break;
            case "2-4-1G":
                startDialog("2-4-2");
                break;
            case "2-4-2":
                startGame("2-4-2G", 3);
                break;
            case "2-4-2G":
                startDialog("2-4-3");
                break;
            case "2-4-3":
                startGame("2-4-3G", 1);
                break;
            case "2-4-3G":
                startDialog("2-4-4");
                break;
            case "2-4-4":
                startGame("2-4-4G", 2);
                break;
            case "2-4-4G":
                startDialog("2-4-5");
                break;
            case "2-4-5":
                startGame("2-4-5G", 3);
                break;

            ////for"3-0-Test"only
            //case "2-4-5G":
            //    startDialog("3-0-Test");
            //    showData();
            //    break;

            case "2-4-5G":
                startDialog("END-0");
                break;

            default:
                Debug.Log("ERROR_startNext_Status_Undefine");
                break;
        }
    }

    ////////////////////    ////////////////////    ////////////////////
    //for"3-0-Test"only
    //[Header("GameObject")]
    //public GameObject dataGUI;
    //public TMP_Text t1, t2, t3;
    //public void showData() 
    //{
    //    t1.text = Score_water.ToString("0");
    //    t2.text = Score_nutrition.ToString("0");
    //    t3.text = Score_health.ToString("0");
    //    dataGUI.SetActive(true);
    //}
    //for"3-0-Test"only
    ////////////////////    ////////////////////    ////////////////////

    public void updateBG(int bg_index)
    {
        background.GetComponent<SpriteRenderer>().sprite = backgroundSprite[bg_index-1];
    }

    public void blackin()
    {
        blackScreen.GetComponent<Animator>().SetBool("blackout", false);
        blackScreen.GetComponent<Animator>().SetBool("blackin", true);
    }

    public void blackout()
    {
        blackScreen.GetComponent<Animator>().SetBool("blackin", false);
        blackScreen.GetComponent<Animator>().SetBool("blackout", true);
    }

    public void potato_old()
    {
        oldPotato.GetComponent<Image>().sprite = oldoldPotato;
        oldPotatoDialog.GetComponent<Image>().sprite = oldoldPotatoDialog;
    }

}
