using Assets.Scripts.Infrastructure.Factory;
using UnityEngine;

namespace Assets.Scripts.SpawnPool
{
    public class BulletPool : Pool
    {
        private IGameFactory _gameFactory;
        private int _poolCount = 15;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            InitializePool();

        }
        protected override void InitializePool()
        {
            
        }

    }
}