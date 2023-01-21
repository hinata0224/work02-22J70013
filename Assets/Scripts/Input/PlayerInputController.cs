using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;

namespace Player_Input
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField, Header("左ボタン")]
        private Button leftButton;
        [SerializeField, Header("右ボタン")]
        private Button rightButton;

        private CompositeDisposable disposables = new();

        private void Awake()
        {
            PlayerInputPresener.Inject(new PlayerMoveModel());
        }

        void Start()
        {
            leftButton.OnPointerDownAsObservable()
                .Subscribe(_ => PlayerInputPresener.ClickMove(1, true))
                .AddTo(disposables);
            leftButton.OnPointerUpAsObservable()
                .Subscribe(_ => PlayerInputPresener.ClickMove(1, false))
                .AddTo(disposables);

            rightButton.OnPointerDownAsObservable()
                .Subscribe(_ => PlayerInputPresener.ClickMove(2, true))
                .AddTo(disposables);
            rightButton.OnPointerUpAsObservable()
                .Subscribe(_ => PlayerInputPresener.ClickMove(2, false))
                .AddTo(disposables);
        }
    }
}