using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score = 0;


    public void AddScore(int additionalScore)
    {
        score += additionalScore;
        scoreText.text = "Score:" + score;
    }
}
