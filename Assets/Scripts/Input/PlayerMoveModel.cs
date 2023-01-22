using UniRx;
using System;
using UnityEngine;

namespace Player_Input
{
    public interface PlayerMoveData
    {
        void ClickMove(int _check,bool moveFlag);
    }

    public interface InputValue
    {
        IObservable<bool> GetLeftMove();
        IObservable<bool> GetRightMove();
    }

    public class PlayerMoveModel : PlayerMoveData,InputValue
    {
        private static Subject<bool> leftMove = new Subject<bool>();
        private static Subject<bool> rightMove = new Subject<bool>();

        public void ClickMove(int check,bool moveFlag)
        {
            switch (check)
            {
                case 1:
                    leftMove.OnNext(moveFlag);
                    break;
                case 2:
                    rightMove.OnNext(moveFlag);
                    break;
            }
        }

        public IObservable<bool> GetLeftMove()
        {
            return leftMove;
        }

        public IObservable<bool> GetRightMove()
        {
            return rightMove;
        }
    }
}