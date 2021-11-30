using Godot;
using Godot.Collections;

public class StateMachine : Node {
    [Signal]
    public delegate void Transitioned(State fromState, State toState);

    [Export]
    private bool debug = false;

    [Export]
    private NodePath initialState;

    private Control stateMachineDebug;
    private Label stateMachineDebugLabel;
    private State state;

    public async override void _Ready() {
        AddToGroup("StateMachine");
        await ToSignal(Owner, "ready");

        if (initialState == null) {
            GD.PushError("StateMachine.initialState not initialized");
            GetTree().Quit();
        }

        stateMachineDebug = Owner.GetNode<Control>("StateMachineDebug");
        stateMachineDebugLabel = stateMachineDebug.GetNode<Label>("Label");

        state = GetNode<State>(initialState);
        state.Enter();
        EmitSignal("Transitioned", null, state);
    }

    public override void _Process(float delta) {
        state.Process(delta);
    }

    public override void _PhysicsProcess(float delta) {
        state.PhysicsProcess(delta);
    }

    public override void _UnhandledInput(InputEvent @event) {
        state.UnhandledInput(@event);
    }

    public void TransitionTo(string targetStatePath, Dictionary msg = null) {
        State fromState = state;

        if (!HasNode(targetStatePath)) {
            GD.Print(Owner.Name + " tried to transition from " + fromState.Name + " to " + targetStatePath + " (state does not exist)");
            return;
        }

        state.Exit();
        state = GetNode<State>(targetStatePath);
        state.Enter(msg);
        EmitSignal("Transitioned", fromState, state);
    }

    private void _on_StateMachine_Transitioned(State fromState, State toState) {
        if (fromState == null) {
            GD.Print(Owner.Name + " transitioned to " + toState.Name);
        } else {
            GD.Print(Owner.Name + " transitioned from " + fromState.Name + " to " + toState.Name);
        }

        stateMachineDebugLabel.Text = toState.Name;
    }
}
