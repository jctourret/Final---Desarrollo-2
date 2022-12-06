using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ResultText : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    private void Start()
    {
        TryGetComponent(out textMesh);
        if (SceneManager.singleton.gameWon)
        {
            textMesh.text = "You win.";
        }
        else
        {
            textMesh.text = "You lose.";
        }
    }
}
