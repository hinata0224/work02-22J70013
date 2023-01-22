using UnityEngine;
using TMPro;

namespace Score
{
    public class ScoreVew : MonoBehaviour
    {
        [SerializeField, Header("�X�R�A�e�L�X�g")]
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