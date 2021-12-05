using Godot;
using Godot.Collections;

public class State : Node {
    protected StateMachine stateMachine;

    public async override void _Ready() {
        await ToSignal(Owner, "ready");
        stateMachine = getStateMachine();
    }

    public virtual void Enter(Dictionary msg = null) {
        // Implement what happens when entering state
    }

    public virtual void Exit() {
        // Implement what happens when exiting state
    }

    private StateMachine getStateMachine() {
        Node node = GetParent();

        while (!node.IsInGroup("StateMachine")) {
            node = node.GetParent();
        }

        return (StateMachine) node;
    }
}
