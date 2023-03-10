using UnityEngine;
using TMPro;
using Score;

namespace Result
{
    public class ResultVew : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI nowTime;

        [SerializeField]
        private TextMeshProUGUI resultScoreText;

        [SerializeField]
        private GameObject resultObj;
        [SerializeField]
        private GameObject gameUI;

        public void SetTime(int _nowTime,int limitTime)
        {
            nowTime.text = "残り時間 : " + ( limitTime -_nowTime);
        }

        public void DisplayResult()
        {
            gameUI.SetActive(false);
            resultObj.SetActive(true);
            resultScoreText.text = "あなたの成績は" + ScoreModelPresenter.GetResultScore() + "です。";
        }
    }
}