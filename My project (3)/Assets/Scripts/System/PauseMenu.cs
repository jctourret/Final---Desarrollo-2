using UnityEngine;
namespace TankGame
{
    public class PauseMenu : MonoBehaviour
    {
        bool pause = false;
        public void OnPauseClick()
        {
            pause = !pause;
            gameObject.SetActive(pause);
            if (gameObject.activeSelf)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }
}