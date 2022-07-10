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
        character.AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
    }
}

public class MoveLeft : Command
{
    public override void Execute(Rigidbody2D character)
    {
        character.AddForce(new Vector2(0, -1), ForceMode2D.Impulse);
    }
}

public class MoveUp : Command
{
    public override void Execute(Rigidbody2D character)
    {
        character.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
    }
}

public class MoveDown : Command
{
    public override void Execute(Rigidbody2D character)
    {
        character.AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
    }
}
public class DoNothing : Command
{
    public override void Execute(Rigidbody2D character)
    {
        
    }
}
