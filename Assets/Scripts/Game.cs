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

    void Awake()
    {
        Control = this;
    }

    public void startDialog(string status)
    {
        currentStatus = status;
        dialogSys.SetActive(true);
    }
}
