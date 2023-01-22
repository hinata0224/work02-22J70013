using System.Collections.Generic;
using UnityEngine;
using Score;

namespace Item
{
    public interface IReadItemSpone
    {
        void CreateItem(Vector3 _pos);
    }
    public class ItemSpone : MonoBehaviour, IReadItemSpone
    {
        [SerializeField,Header("���莞�̃X�R�A")]
        private int getScore = 100;

        [SerializeField, Header("�A�C�e���̐�����")]
        private int sponeValue = 20;

        [SerializeField, Header("��x�ɐ������鐔�̏��")]
        private int sponevalue = 3;

        [SerializeField,Header("�����͈�")]
        private float createRange = 10;
        [SerializeField, Header("�������̍���")]
        private float createHeight = 6;

        [SerializeField, Header("�����Ԋu")]
        private float createTime = 3f;

        [SerializeField]
        private Transform itemParent;

        private List<GameObject> items = new List<GameObject>();

        [SerializeField]
        private ItemObjectPool pool;

        void Awake()
        {
            ScoreModelPresenter.Inject(new ScoreModel());
            ItemSponePresenter.Inject(new ItemSponeModel(createRange, createHeight, createTime), this);
        }

        private void Start()
        {
            for(int i = 0; i < sponeValue; i++)
            {
                GameObject temp = pool.Create();
                temp.GetComponent<ItemController>().Init(this);
            }
        }

        public void CreateItem(Vector3 _pos)
        {
            float value = Random.Range(0, createTime);
            GameObject obj = pool.GetCreateObj(itemParent);
            obj.GetComponent<ItemController>().SetItem();
            obj.transform.position = _pos;
            items.Add(obj);
            ItemSponePresenter.ChengeTimer(value);
        }

        public void GetItem(GameObject _obj)
        {
            items.Remove(_obj);
            pool.DeleteObj(_obj);
            ScoreModelPresenter.AddScore(getScore);
        }

        public void DeleteObj(GameObject _obj)
        {
            items.Remove(_obj);
            pool.DeleteObj(_obj);
        }

        public void EndGame()
        {
            for(int i = 0; i < items.Count; i++)
            {
                items[i].GetComponent<ItemController>().GameEnd();
            }
            pool.EndGame();
        }
    }
}