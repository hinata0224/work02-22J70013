using Other_Script;
using UniRx;
using UnityEngine;

namespace Item
{
    [RequireComponent(typeof(Rigidbody))]
    public class ItemController : MonoBehaviour
    {
        [SerializeField, Header("—Ž‰ºŠJŽnŽžŠÔ")]
        private float startTime = 3f;

        private Rigidbody rb;

        private CompositeDisposable disposables = new();

        private ItemSpone spone;
        private TimerModel timer;

        public void Init(ItemSpone _spone)
        {
            spone = _spone;
        }

        public void SetItem()
        {
            timer = new();
            timer.GetEndTimer()
                .Subscribe(_ => DisplayItem());

            timer.SetTimer(startTime);
        }

        public void GameEnd()
        {
            timer.EndTimer();
        }

        private void OnEnable()
        {
            if(rb == null)
            {
                rb = GetComponent<Rigidbody>();
                rb.useGravity = false;
            }
        }

        private void DisplayItem()
        {
            rb.useGravity = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                timer.EndTimer();
                spone.GetItem(gameObject);
            }
            else if (other.CompareTag("Wall"))
            {
                timer.EndTimer();
                spone.DeleteObj(gameObject);
            }
        }
    }
}