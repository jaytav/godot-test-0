using Godot;

public class Entity : Node2D {
    [Signal]
    public delegate void StartTurn();

    [Signal]
    public delegate void EndTurn();
}
