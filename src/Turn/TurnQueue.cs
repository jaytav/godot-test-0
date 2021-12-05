using Godot;
using Godot.Collections;

public class TurnQueue : Node {
    private Array entities;
    private Entity activeEntity;

    public void SetEntities(Array entities) {
        this.entities = entities;
    }

    public void StartNextTurn() {
        if (activeEntity != null) {
            activeEntity.Disconnect("EndTurn", this, "StartNextTurn");
            entities.Add(activeEntity);
        }

        activeEntity = (Entity) entities[0];
        activeEntity.Connect("EndTurn", this, "StartNextTurn");
        activeEntity.EmitSignal("StartTurn");
        entities.RemoveAt(0);
    }
}
