using System;
using UniRx;

namespace PureMVPTestbed.Health
{
    public interface IHealthPresenter
    {
        void Decrement(int amount);
        void Increment(int amount);
        void Reset();
    }

    public interface IHealthModel
    {
        IReadOnlyReactiveProperty<int> CurrentHealth { get; }
        void Decrement(int amount);
        void Increment(int amount);
        void Reset();
    }

    public interface IHealthView
    {
        void SetHealthValue(int health);
    }

    public class HealthPresenter : IHealthPresenter, IDisposable
    {
        private readonly IHealthModel _model;
        private readonly IHealthView _view;

        private readonly CompositeDisposable _disposable = new();

        public HealthPresenter(IHealthModel model, IHealthView view)
        {
            _model = model;
            _view = view;

            _model.CurrentHealth
                .Subscribe(_view.SetHealthValue)
                .AddTo(_disposable);
        }

        public void Decrement(int amount)
        {
            _model.Decrement(amount);
        }

        public void Increment(int amount)
        {
            _model.Increment(amount);
        }

        public void Reset()
        {
            _model.Reset();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}