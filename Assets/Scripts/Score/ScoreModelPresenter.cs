using UniRx;

namespace Score
{
    public class ScoreModelPresenter 
    {
        private static CompositeDisposable disposables = new();

        private static IReadScore score;
        public static void Inject(IReadScore _score)
        {
            score = _score;
        }

        public static void AddScore(int _score)
        {
            score.AddScore(_score);
        }

        public static void ScoreCheck(ScoreVew vew)
        {
            score.GetScore()
                .Subscribe(x => vew.DisplayScore(x))
                .AddTo(disposables);
        }

        public static int GetResultScore()
        {
            return score.GetResultScore();
        }

        public static void GameEnd()
        {
            disposables.Dispose();
        }
    }
}