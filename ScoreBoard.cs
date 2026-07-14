using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreBoardText;
   int score = 0;

    public void IncreaseScore(int amount)  //using this in our enemy class;
    {
        score = score + amount;
        scoreBoardText.text = score.ToString(); //This will give that score value to scoreBoard text which will be displayed on screen. ToString converts score from int to string cause we need string reference in scoreBoardText.text;
    }
}
