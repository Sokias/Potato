using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSysTest : MonoBehaviour
{
    public GameObject DSys;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Game.Control.currentStatus = "test1";
            Game.Control.changeCurrentTextFile();
            DSys.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Game.Control.currentStatus = "test2";
            Game.Control.changeCurrentTextFile();
            DSys.SetActive(true);
        }
    }
}
