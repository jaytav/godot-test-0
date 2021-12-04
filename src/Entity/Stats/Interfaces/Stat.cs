using Godot;

public abstract class Stat : Node {
    [Signal]
    public delegate void ValueUpdated(int value);

    [Export]
    public int InitialValue;

    private int _value;

    public int Value {
        get {
            return _value;
        }

        set {
            SetValue(value);
        }
    }

    public override void _Ready() {
        Value = InitialValue;
    }

    public virtual void SetValue(int value) {
        _value = value;
        EmitSignal(nameof(ValueUpdated), _value);
    }
}
