using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text score_Text;

    public int lives = 3 ;

    public Image lives_Image;
    public Sprite[] lives_Sprites;
 

    void Start()
    {
        
    }

    void Update()
    {
        score_Text.text = "Score: " + score;

        lives_Image.sprite = lives_Sprites[lives];
    }


    public void increaseScore() {

        score += 20;

    }




}
