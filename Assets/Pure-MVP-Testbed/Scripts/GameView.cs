using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace PureMVPTestbed.Game
{
    public class GameView : MonoBehaviour, IGameView
    {
        public event Action<int> OnDamage;
        public event Action OnReset;

        [SerializeField] private Button damageButton;
        [SerializeField] private Button resetButton;

        [SerializeField] private int damageAmount = 10;


        private void Start()
        {
            damageButton
                .OnPointerClickAsObservable()
                .Subscribe(_ => OnDamage?.Invoke(damageAmount))
                .AddTo(gameObject);

            resetButton
                .OnPointerClickAsObservable()
                .Subscribe(_ => OnReset?.Invoke())
                .AddTo(gameObject);
        }
    }
}