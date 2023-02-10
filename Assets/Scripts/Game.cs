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
    public TextAsset[] textFile = new TextAsset[2];
    public TextAsset currentTextFile;

    void Awake()
    {
        Control = this;
        currentTextFile = textFile[0];
    }

    public void changeCurrentTextFile()
    {
        switch (currentStatus)
        {
            case "test1":
                currentTextFile = textFile[0];
                break;
            case "test2":
                currentTextFile = textFile[1];
                break;

            default:
                break;
        }
    }

}
