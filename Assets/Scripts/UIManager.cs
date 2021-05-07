using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text score_Text;

    void Start()
    {
        
    }

    void Update()
    {
        score_Text.text = "Score: " + score;
        
    }


    public void increaseScore() {

        score += 20;

    }

}
