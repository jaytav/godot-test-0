using Godot;
using Godot.Collections;

public class Active : State {
    public override void UnhandledInput(InputEvent @event) {
        if (@event.IsActionPressed("ui_accept")) {
            Owner.EmitSignal("EndTurn");
        }
    }
}
