using UnityEngine;
using Player_Input;
using UniRx;
using UniRx.Triggers;

namespace Player_Move
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField,Header("ˆÚ“®‘¬“x")]
        private float spead = 2f;

        private Rigidbody rb;

        private CompositeDisposable disposables = new();

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        private void Start()
        {
            PlayerMovePresenter.Inject(new PlayerMoveModel(), this);
        }

        public void Move(int _vector)
        {
            Vector3 move = new Vector3(_vector * spead, 0, 0);
            rb.velocity = move;
            disposables.Clear();
            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                }).AddTo(disposables);
        }

        public void GameEnd()
        {
            disposables.Dispose();
        }
    }
}