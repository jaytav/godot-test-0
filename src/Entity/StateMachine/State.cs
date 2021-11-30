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

    public void Process(float delta) {
        // Implement what happens in stateMachine._Process(float delta)
    }

    public void PhysicsProcess(float delta) {
        // Implement what happens in stateMachine._PhysicsProcess(float delta)
    }

    public void UnhandledInput(InputEvent @event) {
        // Implement what happens in stateMachine._UnhandledInput(InputEvent @event)
    }

    private StateMachine getStateMachine() {
        Node node = GetParent();

        while (!node.IsInGroup("StateMachine")) {
            node = node.GetParent();
        }

        return (StateMachine) node;
    }
}
