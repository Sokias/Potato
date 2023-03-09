using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame01_Control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(endMinigame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        Game.Control.startNext();
    }

    IEnumerator endMinigame()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
