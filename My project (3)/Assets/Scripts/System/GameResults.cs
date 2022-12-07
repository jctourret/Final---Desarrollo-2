using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace TankGame
{
    public class GameResults : MonoBehaviour
    {
        HighscoresData data;
        [SerializeField] TextMeshProUGUI currentScore;
        [SerializeField] List<TextMeshProUGUI> highscoresUI;
        // Start is called before the first frame update
        void Start()
        {

            data = new HighscoresData();
            if (SaveSystem.LoadHighscores() != null)
            {
                data = SaveSystem.LoadHighscores();
            }
            int newScore = (int)SceneManager.singleton.score;
            currentScore.text = "Your Score: " + newScore;

            for (int i = 0; i < data.scores.Length; i++)
            {
                if (newScore > data.scores[i])
                {
                    int aux = data.scores[i];
                    data.scores[i] = newScore;
                    newScore = aux;
                }
                highscoresUI[i].text = highscoresUI[i].name + ": " + data.scores[i];
            }
            SaveSystem.SaveHighschores(data);


        }
    }
}