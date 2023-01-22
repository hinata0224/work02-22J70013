using UnityEngine;
using TMPro;

namespace Score
{
    public class ScoreVew : MonoBehaviour
    {
        [SerializeField, Header("スコアテキスト")]
        private TextMeshProUGUI scoreText;

        private void Start()
        {
            ScoreModelPresenter.ScoreCheck(this);
        }
        public void DisplayScore(int _score)
        {
            scoreText.text = "Score : " + _score;
        }
    }
}