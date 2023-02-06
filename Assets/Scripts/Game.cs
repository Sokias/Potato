using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Control;

    [Header("FlowControl")]
    public string currentStatus = "undefine";

    [Header("TextAsset")]
    public TextAsset[] textFile = new TextAsset[1];
    public TextAsset currentTextFile;

    void Awake()
    {
        Control = this;
        currentTextFile = textFile[0];
    }

    public void changeCurrentStatus(string status)
    {
        currentStatus = status;
    }


}
