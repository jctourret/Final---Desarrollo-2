using TMPro;
using UnityEngine;

public class UI_Score : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    private void Awake()
    {
        gameObject.TryGetComponent(out textMesh);
    }
    private void OnEnable()
    {
        GameManager.onScoreUpdate += UpdateScore;
    }

    private void OnDisable()
    {
        GameManager.onScoreUpdate -= UpdateScore;
    }
    
    void UpdateScore(float newScore)
    {
        textMesh.text = "Score: " + newScore.ToString();
    }
}
