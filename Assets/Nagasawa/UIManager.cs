using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _scoreText;

    void Update()
    {
        _scoreText.text = ScoreManager.CurrentScore.ToString();
    }
}
