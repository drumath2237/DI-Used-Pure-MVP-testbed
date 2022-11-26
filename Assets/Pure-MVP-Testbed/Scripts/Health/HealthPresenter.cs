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

    public class HealthPresenter : IHealthPresenter
    {
        private IHealthModel _model;
        private IHealthView _view;
        
        public HealthPresenter(IHealthModel model, IHealthView view)
        {
            _model = model;
            _view = view;
        }
        
        public void Decrement(int amount)
        {
            throw new System.NotImplementedException();
        }

        public void Increment(int amount)
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}