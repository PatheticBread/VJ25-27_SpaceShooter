using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int totalScore;
    [SerializeField] private TextMeshProUGUI scoreDisplay;

    public void AddScore(int scoretoAdd)
    {
        totalScore += scoretoAdd;
        scoreDisplay.text = totalScore.ToString();
    }
}
