using UniRx;
using Player_Input;

namespace Player_Move
{
    public class PlayerMovePresenter
    {
        private static InputValue moveData;
        private static PlayerMove move;

        private static CompositeDisposable disposables = new();

        public static void Inject(InputValue _data, PlayerMove _move)
        {
            moveData = _data;
            move = _move;

            moveData.GetLeftMove()
                .Where(x => x)
                .Subscribe(_ => move.Move(1))
                .AddTo(disposables);
            moveData.GetLeftMove()
                .Where(x => !x)
                .Subscribe(_ => move.Move(0))
                .AddTo(disposables);

            moveData.GetRightMove()
                .Where(x => x)
                .Subscribe(_ => move.Move(-1))
                .AddTo(disposables);
            moveData.GetRightMove()
                .Where(x => !x)
                .Subscribe(_ => move.Move(0))
                .AddTo(disposables);
        }
    }
}