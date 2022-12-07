using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    [SerializeField] Button playButton;

    private void Start()
    {
        playButton.onClick.AddListener(() => Application.Quit());
    }
}
