using Robust.Shared.Audio;
using Robust.Shared.GameStates; // Юзинг новый

namespace Content.Server.DeadSpace.Components.NightVision;

[RegisterComponent, NetworkedComponent]  // NetworkedComponent новый
public sealed partial class PNVComponent : Component
{
    [DataField]
    public Color? Color = null;

    [DataField]
    [ViewVariables(VVAccess.ReadOnly)]
    public bool HasNightVision = false;

    [DataField]
    [ViewVariables(VVAccess.ReadOnly)]
    public bool Animation = true;

    [DataField]
    [ViewVariables(VVAccess.ReadOnly)]
    public SoundSpecifier? ActivateSound = null;

    // Офф и Он стейт
    [DataField]
    public string OffState = string.Empty;

    [DataField]
    public string OnState = string.Empty;

    [Serializable]
    private sealed class PNVComponentState : ComponentState
    {
        public string OffState { get; }
        public string OnState { get; }
        public PNVComponentState(string offState, string onState)
        {
            OffState = offState;
            OnState = onState;
        }
    }
}