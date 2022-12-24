using PureMVPTestbed.Health;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace PureMVPTestbed.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameView gameView;
        [SerializeField] private HealthView healthView;

        [SerializeField] private int minHealth = 0;
        [SerializeField] private int maxHealth = 100;


        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GamePresenter>();
            builder.RegisterComponent(gameView).As<IGameView>();
            builder.Register<IGameModel, GameModel>(Lifetime.Singleton);

            builder.Register<IHealthPresenter, HealthPresenter>(Lifetime.Singleton);
            builder.RegisterComponent(healthView).As<IHealthView>();
            builder.Register<IHealthModel>(
                _ => new HealthModel(minHealth, maxHealth),
                Lifetime.Singleton
            );

            builder.RegisterBuildCallback(_ =>
            {
                healthView.SetSliderMinMaxValue(min: minHealth, max: maxHealth);
            });
        }
    }
}