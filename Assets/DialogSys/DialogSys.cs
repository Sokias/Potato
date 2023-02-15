using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSys : MonoBehaviour
{
    [Header("TextFIles")]
    public TextAsset[] textFile = new TextAsset[2];

    [Header("TextObjects")]
    public TMP_Text textLabel1;
    public TMP_Text textLabel2;
    public TMP_Text textLabelB;

    [Header("GameObjects")]
    public GameObject Character1;
    public GameObject Character2;
    public GameObject Dialog1;
    public GameObject Dialog2;
    public GameObject DialogB;

    int index;
    TextAsset currentTextFile;
    List<string> textList = new List<string>();

    private void OnEnable()
    {
        index = 0;
        setCurrentTextFile();
        GetTextFromFile(currentTextFile);
        displayNext();
    }

    private void OnDisable() 
    {
        dialogEnd();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index++;
            displayNext();
        }
    }

    public void setCurrentTextFile()
    {
        switch (Game.Control.currentStatus)
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

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            textList.Add(line.Replace("\\n", ""));
        }
    }

    void displayNext()
    {
        var status = false;
        //delete the empty char at the end / Windows Only!
        switch (textList[index])//.Substring(0, textList[index].Length - 1)) //windows only
        {
            case "&wait":
                status = true;
                break;
            case "&end": //on windows change it to &en
                dialogEnd();
                break;

            case "&c1_on":
                Character1.SetActive(true);
                break;
            case "&c1_off":
                Character1.SetActive(false);
                break;
            case "&c2_on":
                Character2.SetActive(true);
                break;
            case "&c2_off":
                Character2.SetActive(false);
                break;
            case "&d1_on":
                Dialog1.SetActive(true);
                break;
            case "&d1_off":
                Dialog1.SetActive(false);
                break;
            case "&d2_on":
                Dialog2.SetActive(true);
                break;
            case "&d2_off":
                Dialog2.SetActive(false);
                break;
            case "&db_on":
                DialogB.SetActive(true);
                break;
            case "&db_off":
                DialogB.SetActive(false);
                break;

            default:
                var line = textList[index].Split(':');
                switch (line[0])
                {
                    case "d1":
                        textLabel1.SetText(line[1]);
                        break;
                    case "d2":
                        textLabel2.SetText(line[1]);
                        break;
                    case "db":
                        textLabelB.SetText(line[1]);
                        break;
                }
                break;
        }

        if (status) { return; }
        index++;
        displayNext();

    }

    void dialogEnd()
    {
        index = 0;
        Character1.SetActive(false);
        Character2.SetActive(false);
        Dialog1.SetActive(false);
        Dialog2.SetActive(false);
        DialogB.SetActive(false);
        gameObject.SetActive(false);
        return;
    }

    /** ControlReference
     * &c1_on
     * &c1_off
     * &c2_on
     * &c2_off
     * &d1_on
     * &d1_off
     * &d2_on
     * &d2_off
     * &db_on
     * &db_off
     * d1:[content]
     * d2:[content]
     * db:[content]
     * &wait
     * &end
     */

}
