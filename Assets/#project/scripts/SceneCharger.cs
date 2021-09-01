using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCharger : MonoBehaviour
{
    public void Change(string sceneName) {

        SceneManager.LoadScene(sceneName);
    }

    public void Exit() {
        Application.Quit();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
