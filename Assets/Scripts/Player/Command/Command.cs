using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [Command Pattern]
/// Abstract Command
/// </summary>
public abstract class Command
{
    public abstract void Execute(Rigidbody2D rb2d, float speed, MoveController moveController);
}

/// <summary>
/// [Command Pattern]
/// Move Right Command
/// </summary>
public class MoveRight : Command
{
    public override void Execute(Rigidbody2D rb2d, float speed, MoveController moveController)
    {
        //using Rigidbody2D.velocity to move
        rb2d.velocity = new Vector2(1 * speed, 0);

        //change Animation following move Direction (using Controller - State Design Pattern)
        moveController.MoveRightAnimation();
    }
}

/// <summary>
/// [Command Pattern]
/// Move Left Command
/// </summary>
public class MoveLeft : Command
{
    public override void Execute(Rigidbody2D rb2d, float speed, MoveController moveController)
    {
        rb2d.velocity = new Vector2(-1 * speed, 0);

        //change Animation following move Direction (using Controller - State Design Pattern)
        moveController.MoveLeftAnimation();
    }
}

/// <summary>
/// [Command Pattern]
/// Move Up Command
/// </summary>
public class MoveUp : Command
{
    public override void Execute(Rigidbody2D rb2d, float speed, MoveController moveController)
    {
        rb2d.velocity = new Vector2(0, 1 * speed);

        //change Animation following move Direction (using Controller - State Design Pattern)
        moveController.MoveUpAnimation();
    }
}

/// <summary>
/// [Command Pattern]
/// Move Down Command
/// </summary>
public class MoveDown : Command
{
    public override void Execute(Rigidbody2D rb2d, float speed, MoveController moveController)
    {
        rb2d.velocity = new Vector2(0, -1 * speed);

        //change Animation following move Direction (using Controller - State Design Pattern)
        moveController.MoveDownAnimation();
    }
}

/// <summary>
/// [Command Pattern]
/// Stop Command
/// </summary>
public class Stop : Command
{
    public override void Execute(Rigidbody2D rb2d, float speed, MoveController moveController)
    {
        rb2d.velocity = new Vector2(0, 0);
    }
}

/// <summary>
/// [Command Pattern]
/// To remove using of Command
/// </summary>
public class DoNothing : Command
{
    public override void Execute(Rigidbody2D rb2d, float speed, MoveController moveController)
    {
        
    }
}
