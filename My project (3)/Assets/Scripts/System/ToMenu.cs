using System;
using UnityEngine;
using UnityEngine.UI;
namespace TankGame
{
    public class ToMenu : MonoBehaviour
    {
        [SerializeField] Button menuButton;

        public static Action onClick;
        private void Start()
        {
            menuButton.onClick.AddListener(() => onClick?.Invoke());
        }
    }
}