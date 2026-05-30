using Content.Shared.DeadSpace.NightVision;
using Robust.Client.GameObjects;

namespace Content.Client.DeadSpace.NightVision;

public sealed class NightVisionVisualizer : VisualizerSystem<NightVisionComponent>
{
    protected override void OnAppearanceChange(EntityUid uid, NightVisionComponent component, ref AppearanceChangeEvent args)
    {
        // В рофл создано
    }

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<NightVisionComponent, ComponentHandleState>(OnHandleState);
    }

    private void OnHandleState(EntityUid uid, NightVisionComponent component, ref ComponentHandleState args)
    {
        if (args.Current is not NightVisionComponentState state)
            return;

        // Обновляем компонент
        component.Color = state.Color;
        component.IsNightVision = state.IsNightVision;
        component.ActivateSound = state.ActivateSound;
        component.Animation = state.Animation;
        component.Duration = state.Duration;
        component.SourceHelmet = state.SourceHelmet;

        // Меняем спрайт на шлеме
        if (state.SourceHelmet is { Valid: true } helmet)
        {
            if (TryComp<SpriteComponent>(helmet, out var sprite) &&
                TryComp<PNVComponent>(helmet, out var pnv))
            {
                var targetState = state.IsNightVision ? pnv.OnState : pnv.OffState;
                if (!string.IsNullOrEmpty(targetState) && sprite.LayerCount > 0)
                {
                    sprite.LayerSetState(0, targetState);
                }
            }
        }
    }
}