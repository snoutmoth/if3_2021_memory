using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCharger : MonoBehaviour
{
    public void Change(string sceneName) {

        SceneManager.LoadScene(sceneName);
    }

    public void LoadGameScene(int level) { //méthode à part, on lui fait passer le niveau de difficulté
        int row, col;
        switch (level) {
            case 1: 
                row = 2; 
                col = 3;
                break;
            case 2: 
                row = 3; 
                col = 4;
                break;
        default: 
            row = 4; 
            col = 5;
            break;
        }
        PlayerPrefs.SetInt("row", row); //créer ou remplacer variable avec le SetInt, lui donner une valeur que je pourrai récupérer dans uneautre scène + tard
        PlayerPrefs.SetInt("col", col);
        SceneManager.LoadScene("SampleScene");
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
