using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;                //instance mida saab kasutada teisted skriptides
    public TMP_Text scoreText;                          //Skoori tekst
    int score = 0;                                      //Skoor on 0

    //Awake funktsioon määrab ära, mis juhtub juba enne mängu algust
    private void Awake(){
        instance = this;
    }

    //Start funktsioon käivitatakse mängu käima pannes 1 korra
    void Start()
    {
        ResetPoint();
        scoreText.text = "Skoor:" + score.ToString();
    }

    //Lisame skoorile 1 punkti
    public void AddPoint(){
        score++;
        scoreText.text = "Skoor:" + score.ToString();
    }

    //Resetime skoori 0
    public void ResetPoint(){
        score = 0;
        scoreText.text = "Skoor:" + score.ToString();
    }
}
