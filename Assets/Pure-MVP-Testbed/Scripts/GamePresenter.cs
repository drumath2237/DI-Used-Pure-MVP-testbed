using System;
using PureMVPTestbed.Health;
using VContainer.Unity;

namespace PureMVPTestbed.Game
{
    public interface IGameModel
    {
    }

    public interface IGameView
    {
        event Action<int> OnDamage;
        event Action OnReset;
    }

    public class GamePresenter : IStartable, IDisposable
    {
        private IGameModel _gameModel;
        private IGameView _gameView;

        private IHealthPresenter _healthPresenter;

        public GamePresenter(IGameModel gameModel, IGameView gameView, IHealthPresenter healthPresenter)
        {
            _gameModel = gameModel;
            _gameView = gameView;
            _healthPresenter = healthPresenter;
        }

        public void Start()
        {
            _gameView.OnDamage += DamageHealth_OnDamage;
            _gameView.OnReset += ResetHealth_OnReset;
        }

        private void DamageHealth_OnDamage(int amount)
        {
            _healthPresenter.Decrement(amount);
        }

        private void ResetHealth_OnReset()
        {
            _healthPresenter.Reset();
        }

        public void Dispose()
        {

            _gameView.OnDamage -= DamageHealth_OnDamage;
            _gameView.OnReset -= ResetHealth_OnReset;
        }
    }
}