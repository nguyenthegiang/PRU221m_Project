using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Rigidbody2D character);
}

public class MoveRight : Command
{
    public override void Execute(Rigidbody2D character)
    {
        character.velocity = new Vector2(1, 0);
    }
}

public class MoveLeft : Command
{
    public override void Execute(Rigidbody2D character)
    {
        character.velocity = new Vector2(-1, 0);
    }
}

public class MoveUp : Command
{
    public override void Execute(Rigidbody2D character)
    {
        character.velocity = new Vector2(0, 1);
    }
}

public class MoveDown : Command
{
    public override void Execute(Rigidbody2D character)
    {
        character.velocity = new Vector2(0, -1);
    }
}
public class DoNothing : Command
{
    public override void Execute(Rigidbody2D character)
    {
        
    }
}
