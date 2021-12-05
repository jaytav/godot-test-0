using Godot;
using Godot.Collections;

public class TurnSkipActive : State {
    public override void Enter(Dictionary msg = null) {
        GetNode<Timer>("Timer").Start(2);
    }

    private void _on_Timer_timeout() {
        Owner.EmitSignal("EndTurn");
    }
}
