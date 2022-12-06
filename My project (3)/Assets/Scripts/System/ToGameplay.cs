using System;
using UnityEngine;
using UnityEngine.UI;

public class ToGameplay : MonoBehaviour
{
    [SerializeField]Button playButton;

    public static Action onClick;
    private void Start()
    {
        playButton.onClick.AddListener(() => onClick?.Invoke());
    }
}
