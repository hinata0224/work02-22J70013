using Other_Script;
using UnityEngine;
using System;
using UniRx;

namespace Item
{
    public interface IReadSpone
    {
        Vector3 GetSponePos();
        IObservable<Unit> GetTimeEnd();
        void Dispose();
        void RestartTimer(float time);
    }
    public class ItemSponeModel : IReadSpone
    {
        private float range;
        private float height;

        private TimerModel timer = new();

        public ItemSponeModel(float _range,float _height,float time)
        {
            range = _range;
            height = _height;
            timer.SetTimer(time);
        }

        public void RestartTimer(float time)
        {
            Dispose();
            timer = new();
            timer.SetTimer(time);
        }

        public Vector3 GetSponePos()
        {
            float temp = UnityEngine.Random.Range(-range, range);
            timer.RestertTimer();
            return new Vector3(temp, height, 0);
        }

        public void Dispose()
        {
            timer.EndTimer();
        }

        public IObservable<Unit> GetTimeEnd()
        {
            return timer.GetEndTimer();
        }
    }
}