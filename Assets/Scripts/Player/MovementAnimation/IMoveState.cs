using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// [State Deisgn Pattern: Main Character Movement]
/// General interface for all movement states, must be implemented by all movement states
/// </summary>
public interface IMoveState
{
    /// <summary>
    /// Handle method for all states, gets called when change to new state. 
    /// Pass in controller to make changes to MainCharacter
    /// </summary>
    /// <param name="controller">the controller for main character object</param>
    void Handle(MoveController controller);
}
