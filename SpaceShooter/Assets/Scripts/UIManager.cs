using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] public int totalScore;
    [SerializeField] private TextMeshProUGUI scoreDisplay;

    void Start()
    {
        scoreDisplay.text = totalScore.ToString();
    }

    public void AddScore(int scoretoAdd)
    {
        totalScore += scoretoAdd;
        scoreDisplay.text = totalScore.ToString();
    }
}
