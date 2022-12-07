using UnityEngine;
using TMPro;
namespace TankGame
{
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
}