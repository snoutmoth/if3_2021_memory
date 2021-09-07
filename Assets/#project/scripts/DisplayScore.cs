using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        float time = PlayerPrefs.GetFloat("timer", 0f); //on récupère le temps au moment où on a gagné
        tmp.text = "Time: \n" + time.ToString("N2"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
