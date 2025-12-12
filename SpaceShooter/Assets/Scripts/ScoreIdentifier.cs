using UnityEngine;

public class ScoreIdentifier : MonoBehaviour
{
    [SerializeField] private int score;

    void OnDestroy()
    {
        GameObject.Find("UIManager").GetComponent<UIManager>().AddScore(score);
    }
}
