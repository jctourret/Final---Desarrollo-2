using UnityEngine;
using UnityEngine.UI;
namespace TankGame
{
    public class ExitGame : MonoBehaviour
    {
        [SerializeField] Button playButton;
        AudioSource source;
        private void Start()
        {
            source = GetComponent<AudioSource>();
            playButton.onClick.AddListener(() => { Invoke("QuitGame", source.clip.length);source.Play();}) ;
        }

        void QuitGame()
        {

        }
    }
}