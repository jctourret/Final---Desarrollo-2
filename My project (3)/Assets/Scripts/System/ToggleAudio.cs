using System;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField] Button audioButton;

    public static Action onClick;
    private void Start()
    {
        audioButton.onClick.AddListener(() => onClick?.Invoke());
    }
}
