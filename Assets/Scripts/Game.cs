using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Control;

    [Header("FlowControl")]
    public string currentStatus = "undefine";

    [Header("DialogSys")]
    public GameObject dialogSys;
    public int savedAnswer = -1;

    [Header("GameSystem")]
    public GameObject gameSys_01;

    private void Awake()
    {
        Control = this;
    }

    private void Start()
    {
        startDialog("0-1");
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
                startDialog("1-2");
                break;


            default:
                Debug.Log("startNext_Status_ERROR");
                break;
        }
    }

}
