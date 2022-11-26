using UniRx;

namespace PureMVPTestbed.Health
{
    public class HealthModel : IHealthModel
    {
        private readonly ReactiveProperty<int> _currentHealth;
        public IReadOnlyReactiveProperty<int> CurrentHealth => _currentHealth;

        private readonly int _maxValue;
        private readonly int _minValue;

        public HealthModel(int min, int max)
        {
            _minValue = min;
            _maxValue = max;
            _currentHealth = new ReactiveProperty<int>(max);
        }

        public void Decrement(int amount)
        {
            if (_currentHealth.Value - amount < _minValue)
            {
                _currentHealth.Value = _minValue;
                return;
            }

            _currentHealth.Value -= amount;
        }

        public void Increment(int amount)
        {
            if (_currentHealth.Value + amount > _maxValue)
            {
                _currentHealth.Value = _maxValue;
                return;
            }

            _currentHealth.Value += amount;
        }

        public void Reset()
        {
            _currentHealth.Value = _maxValue;
        }
    }
}