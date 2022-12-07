namespace TankGame
{
    [System.Serializable]
    public class HighscoresData
    {
        public int[] scores;
        public HighscoresData()
        {
            scores = new int[3];
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = 0;
            }
        }
    }
}