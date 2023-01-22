using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class ItemObjectPool : MonoBehaviour
    {
        [SerializeField]
        private GameObject createObj;

        private List<GameObject> objectPoolList = new();
        public GameObject Create()
        {
            GameObject obj = Instantiate(createObj);
            obj.SetActive(false);
            obj.transform.parent = transform;
            objectPoolList.Add(obj);
            return obj;
        }

        public GameObject GetCreateObj(Transform parentobj)
        {
            GameObject obj = objectPoolList[0];
            obj.SetActive(true);
            obj.transform.parent = parentobj;
            objectPoolList.Remove(obj);
            return obj;
        }

        public void DeleteObj(GameObject obj)
        {
            objectPoolList.Add(obj);
            obj.SetActive(false);
            obj.transform.parent = transform;
        }

        public void EndGame()
        {
            for(int i = 0; i < objectPoolList.Count; i++)
            {
                objectPoolList[i].GetComponent<ItemController>().GameEnd();
            }
        }
    }
}