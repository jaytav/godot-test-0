using Godot;
using Godot.Collections;

public class Game : Node2D {
    private TurnQueue turnQueue;

    public override void _Ready() {
        turnQueue = new TurnQueue();
        turnQueue.SetEntities(GetNode("Entities").GetChildren());
        turnQueue.StartNextTurn();
    }
}
