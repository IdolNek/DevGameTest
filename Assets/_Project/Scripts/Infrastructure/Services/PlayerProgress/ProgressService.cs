
using System;

namespace Assets.Scripts.Infrastructure.Services.PlayerProgress
{
    public class ProgressService : IProgressService
    {
        private int _currentLevel;
        private int _currrentScore;

        public int CurrentLevel => _currentLevel;

        public int CurrrentScore => _currrentScore;
        public event Action<int> ScoreChanged; 

        public ProgressService()
        {
            _currentLevel = 0;
            _currrentScore = 0;
        }
        
        public void AddScore(int score)
        {
            _currrentScore += score;
            ScoreChanged?.Invoke(_currrentScore);
        }
    }
}