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
            Game.Control.startDialog("1-1");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Game.Control.startDialog("0-1");
        }
    }
}
