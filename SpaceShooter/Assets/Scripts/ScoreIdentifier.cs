using UnityEngine;

public class ScoreIdentifier : MonoBehaviour
{
    [SerializeField] private int score;

    void OnDestroy()
    {
        GameObject.Find("UiMan").GetComponent<UIManager>().AddScore(score); // I'm aware that unity is constantly whining about this, but frankly this is code we did in class and it still works perfectly fine so I'm just gonna let it.
    }
}
