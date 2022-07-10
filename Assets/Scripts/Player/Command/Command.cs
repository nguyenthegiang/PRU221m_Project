using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Rigidbody2D rb2d, float speed);
}

public class MoveRight : Command
{
    public override void Execute(Rigidbody2D rb2d, float speed)
    {
        rb2d.velocity = new Vector2(1 * speed, 0);
    }
}

public class MoveLeft : Command
{
    public override void Execute(Rigidbody2D rb2d, float speed)
    {
        rb2d.velocity = new Vector2(-1 * speed, 0);
    }
}

public class MoveUp : Command
{
    public override void Execute(Rigidbody2D rb2d, float speed)
    {
        rb2d.velocity = new Vector2(0, 1 * speed);
    }
}

public class MoveDown : Command
{
    public override void Execute(Rigidbody2D rb2d, float speed)
    {
        rb2d.velocity = new Vector2(0, -1 * speed);
    }
}

public class Stop : Command
{
    public override void Execute(Rigidbody2D rb2d, float speed)
    {
        rb2d.velocity = new Vector2(0, 0);
    }
}

public class DoNothing : Command
{
    public override void Execute(Rigidbody2D rb2d, float speed)
    {
        
    }
}
