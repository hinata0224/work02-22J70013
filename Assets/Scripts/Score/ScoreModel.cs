using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace Score
{
    public interface IReadScore
    {
        int GetResultScore();
        IObservable<int> GetScore();
        void AddScore(int score);
    }
    public class ScoreModel : IReadScore
    {
        private static ReactiveProperty<int> _score = new(0);

        private IObservable<int> scoreCheck => _score;

        public void AddScore(int score)
        {
            _score.Value += score;
        }

        public int GetResultScore()
        {
            return _score.Value;
        }

        public IObservable<int> GetScore()
        {
            return scoreCheck;
        }
    }
}