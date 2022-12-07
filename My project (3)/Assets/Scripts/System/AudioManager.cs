using UnityEngine;
using UnityEngine.Audio;
namespace TankGame
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] AudioMixer mixer;
        float soundOn = 0f;
        float soundOff = -80f;
        public static AudioManager singleton;
        private void Awake()
        {
            if (singleton == null)
            {
                singleton = this;
                DontDestroyOnLoad(singleton.gameObject);
            }
            else if (singleton != gameObject)
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            ToggleAudio.onClick += changeAudio;
        }
        private void OnDisable()
        {
            ToggleAudio.onClick -= changeAudio;
        }

        private void Start()
        {
            mixer.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));

        }

        void changeAudio()
        {
            mixer.GetFloat("Volume", out float value);
            if (value == soundOn)
            {
                mixer.SetFloat("Volume", soundOff);
                PlayerPrefs.SetFloat("Volume", soundOff);
            }
            else
            {
                mixer.SetFloat("Volume", soundOn);
                PlayerPrefs.SetFloat("Volume", soundOn);
            }
        }
    }
}