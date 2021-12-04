using Godot;

public abstract class BoundStat : Stat {
    [Export]
    public int MinValue;

    [Export]
    public int MaxValue;

    public override void _Ready() {
        if (InitialValue == 0) {
            Value = MaxValue;
        } else {
            base._Ready();
        }
    }

    public override void SetValue(int _value) {
        base.SetValue(Mathf.Clamp(_value, MinValue, MaxValue));
    }
}
