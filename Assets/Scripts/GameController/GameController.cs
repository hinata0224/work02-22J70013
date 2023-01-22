using Other_Script;
using UnityEngine;
using Item;
using Player_Input;
using Player_Move;
using Score;
using UniRx;
using Result;

public interface IReadEndGame
{
    void GameEnd();
}
namespace GameController {
    public class GameController : MonoBehaviour
    {
        [SerializeField, Header("§ŒÀŽžŠÔ")]
        private float gameTime = 30f;

        private CompositeDisposable disposables = new();

        private TimerModel timer = new();

        [SerializeField]
        private ItemSpone itemSpone;
        [SerializeField]
        private PlayerMove playerMove;
        [SerializeField]
        private PlayerInputController playerInput;
        [SerializeField]
        private ResultVew result;

        private void Start()
        {
            timer.GetEndTimer()
                .Subscribe(_ => EndGame())
                .AddTo(disposables);

            timer.GetNowTime
                .Subscribe(x => result.SetTime(x, (int)gameTime))
                .AddTo(disposables);

            timer.SetTimer(gameTime);
        }

        private void EndGame()
        {
            disposables.Dispose();
            itemSpone.EndGame();
            playerMove.GameEnd();
            playerInput.EndGame();
            ItemSponePresenter.TimerDispose();
            ScoreModelPresenter.GameEnd();
            result.DisplayResult();
        }
    }
}