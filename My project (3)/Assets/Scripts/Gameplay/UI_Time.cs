using TMPro;
using UnityEngine;

public class UI_Time : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    private void Awake()
    {
        gameObject.TryGetComponent(out textMesh);
    }
    private void OnEnable()
    {
        GameManager.onTimeUpdate += UpdateTime;
    }

    private void OnDisable()
    {
        GameManager.onTimeUpdate -= UpdateTime;
    }

    void UpdateTime(float newScore)
    {
        textMesh.text = "Time: "+newScore.ToString("F2");
    }
}
