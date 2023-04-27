using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSys : MonoBehaviour
{
    [Header("TextFiles")]
    public TextAsset[] textFile = new TextAsset[31];

    [Header("TextObjects")]
    public TMP_Text textLabel1;
    public TMP_Text textLabel2;
    public TMP_Text textLabel3;//
    public TMP_Text textLabelB;
    public TMP_Text choiceTextLabel1;
    public TMP_Text choiceTextLabel2;
    public TMP_Text choiceTextLabel3;

    [Header("GameObjects")]
    public GameObject Character1, Character2;
    public GameObject Character3;//
    public GameObject Dialog3;//
    public GameObject Dialog1, Dialog2, DialogB;
    public GameObject DialogChoice;
    public GameObject[] Pointer = new GameObject[3];

    int index;
    TextAsset currentTextFile;
    public List<string> textList = new List<string>();
    bool choiceON = false;
    int currentChoice = 0;
    

    private void OnEnable()
    {
        index = 0;

        clearAll();

        setCurrentTextFile();
        GetTextFromFile(currentTextFile);
        displayNext();
    }

    private void OnDisable()
    {
        Game.Control.startNext();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !choiceON)
        {
            index++;
            displayNext();
        }

        if (choiceON)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentChoice == 0) { return; }
                choiceOff();
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentChoice += 1;
                if (currentChoice > 3) { currentChoice = 1; }
                Pointer[0].SetActive(false); Pointer[1].SetActive(false); Pointer[2].SetActive(false);
                Pointer[currentChoice - 1].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentChoice -= 1;
                if (currentChoice < 1) { currentChoice = 3; }
                Pointer[0].SetActive(false); Pointer[1].SetActive(false); Pointer[2].SetActive(false);
                Pointer[currentChoice - 1].SetActive(true);
            }

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
            case "0-1":
                currentTextFile = textFile[2];
                break;
            case "1-1":
                currentTextFile = textFile[3];
                break;
            case "1-1-2":
                currentTextFile = textFile[4];
                break;
            case "1-2":
                currentTextFile = textFile[5];
                break;
            case "1-3-1":
                currentTextFile = textFile[6];
                break;
            case "1-3-2":
                currentTextFile = textFile[7];
                break;
            case "1-3-3":
                currentTextFile = textFile[8];
                break;
            case "2-1":
                currentTextFile = textFile[9];
                break;
            case "2-2":
                currentTextFile = textFile[10];
                break;
            case "2-3-A":
                currentTextFile = textFile[11];
                break;
            case "2-3-B":
                currentTextFile = textFile[12];
                break;
            case "2-4-1":
                currentTextFile = textFile[13];
                break;
            case "2-4-2":
                currentTextFile = textFile[14];
                break;
            case "2-4-3":
                currentTextFile = textFile[15];
                break;
            case "2-4-4":
                currentTextFile = textFile[16];
                break;
            case "2-4-5":
                currentTextFile = textFile[17];
                break;
            case "END-0":
                currentTextFile = textFile[18];
                break;
            case "END-A-1":
                currentTextFile = textFile[19];
                break;
            case "END-A-2":
                currentTextFile = textFile[20];
                break;
            case "END-A-3":
                currentTextFile = textFile[21];
                break;
            case "END-A-4":
                currentTextFile = textFile[22];
                break;
            case "END-B-1":
                currentTextFile = textFile[23];
                break;
            case "END-B-2":
                currentTextFile = textFile[24];
                break;
            case "END-B-3":
                currentTextFile = textFile[25];
                break;
            case "END-B-4":
                currentTextFile = textFile[26];
                break;
            case "END-B-5":
                currentTextFile = textFile[27];
                break;
            case "END-C-1":
                currentTextFile = textFile[28];
                break;
            case "END-C-2":
                currentTextFile = textFile[29];
                break;
            case "END-C-3":
                currentTextFile = textFile[30];
                break;
            case "END-C-4":
                currentTextFile = textFile[31];
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
                //Debug.Log("End");
                //gameObject.SetActive(false);
                break;
            case "&clear":
                clearAll();
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
            case "&c3_on":
                Character3.SetActive(true);
                break;
            case "&c3_off":
                Character3.SetActive(false);
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
            case "&d3_on":
                Dialog3.SetActive(true);
                break;
            case "&d3_off":
                Dialog3.SetActive(false);
                break;
            case "&db_on":
                DialogB.SetActive(true);
                break;
            case "&db_off":
                DialogB.SetActive(false);
                break;

            case "&choice_on":
                choiceOn();
                status = true;
                break;
            case "&save_choice":
                Game.Control.savedAnswer = currentChoice;
                break;

            case "&blackin":
                Game.Control.blackin();
                break;
            case "&blackout":
                Game.Control.blackout();
                break;
            case "&oldpotato":
                Game.Control.potato_old();
                break;

            default:
                var line = textList[index].Split(':');
                switch (line[0])
                {
                    case "&bg_update":
                        Game.Control.updateBG(int.Parse(line[1]));
                        if (int.Parse(line[1]) > 9)
                        {
                            DialogB.GetComponent<Image>().sprite = null;
                            DialogB.GetComponent<Image>().color = new Color32(0, 0, 0, 150);
                            textLabelB.GetComponent<TMP_Text>().color = new Color32(255, 255, 255, 255);
                        }
                        break;
                    case "&delay":
                        status = true;
                        StartCoroutine(delay(int.Parse(line[1])));
                        break;

                    case "d1":
                        textLabel1.SetText(line[1]);
                        break;
                    case "d2":
                        textLabel2.SetText(line[1]);
                        break;
                    case "d3":
                        textLabel3.SetText(line[1]);
                        break;
                    case "db":
                        textLabelB.SetText(line[1]);
                        break;
                    case "c1":
                        choiceTextLabel1.SetText(line[1]);
                        break;
                    case "c2":
                        choiceTextLabel2.SetText(line[1]);
                        break;
                    case "c3":
                        choiceTextLabel3.SetText(line[1]);
                        break;
                    case "d2_choice_ans":
                        switch (currentChoice)
                        {
                            case 0:
                                textLabel2.SetText(line[1]);
                                break;
                            case 1:
                                textLabel2.SetText(line[2]);
                                break;
                            case 2:
                                textLabel2.SetText(line[3]);
                                break;
                            case 3:
                                textLabel2.SetText(line[4]);
                                break;
                        }
                        break;
                }
                break;
        }

        if (status) { return; }
        index++;
        displayNext();

    }

    void choiceOn()
    {
        Dialog1.SetActive(false);
        textLabel1.SetText("");
        currentChoice = 0;
        Pointer[0].SetActive(false); Pointer[1].SetActive(false); Pointer[2].SetActive(false);
        DialogChoice.SetActive(true);
        choiceON = true;
    }

    void choiceOff()
    {
        DialogChoice.SetActive(false);
        choiceON = false;
        index++;
        displayNext();
    }

    void dialogEnd()
    {
        index = 0;
        clearAll();
        gameObject.SetActive(false);
    }

    void clearAll()
    {
        //textList.Clear();
        Character1.SetActive(false);
        Character2.SetActive(false);
        Character3.SetActive(false);
        Dialog1.SetActive(false);
        Dialog2.SetActive(false);
        Dialog3.SetActive(false);
        DialogB.SetActive(false);
        DialogChoice.SetActive(false);
    }

    IEnumerator delay(int time)
    {
        yield return new WaitForSeconds(time);

        index++;
        //status = false;
        displayNext();
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
     * c1:[content]
     * c2:[content]
     * c3:[content]
     * &choice_on
     * &save_choice
     * d2_choice_ans:[ans0]:[ans1]:[ans2]:[ans3]
     * &wait
     * &delay:[time(s)]
     * &blackin
     * &blackout
     * &bg_update:[index]
     * &end
     */

}
