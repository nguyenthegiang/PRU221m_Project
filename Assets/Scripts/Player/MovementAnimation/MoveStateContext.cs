using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// [State Design Pattern]
/// Context class, use to get current state and change state
/// </summary>
class MoveStateContext
{
    //current state of movement
    public IMoveState CurrentState { get; set; }

    // controller to get and/or set properties of movement
    private readonly MoveController _moveController;

    //constructor
    public MoveStateContext(MoveController moveController)
    {
        //instantiate the controller
        _moveController = moveController;
    }

    /// <summary>
    /// Change to new state and call handle method of that state
    /// </summary>
    /// <param name="state">the new state to change to</param>
    public void Transition(IMoveState state)
    {
        CurrentState = state;
        CurrentState.Handle(_moveController);
    }
}