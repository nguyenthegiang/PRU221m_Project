using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// [State Deisgn Pattern: Farm]
/// Context class, use to get current state and change state
/// </summary>
class FarmStateContext
{
    //current state of farm
    public IFarmState CurrentState { get; set; }

    // controller to get and/or set properties of farm
    private readonly FarmController _farmController;

    //constructor
    public FarmStateContext(FarmController farmController)
    {
        //instantiate the controller
        _farmController = farmController;
    }

    /// <summary>
    /// Change to new state and call handle method of that state
    /// </summary>
    /// <param name="state">the new state to change to</param>
    public void Transition(IFarmState state)
    {
        CurrentState = state;
        CurrentState.Handle(_farmController);
    }
}