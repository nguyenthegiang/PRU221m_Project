using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// [State Deisgn Pattern: Farm]
/// General interface for all movement states, must be implemented by all farm states
/// </summary>
public interface IFarmState
{
    /// <summary>
    /// Handle method for all states, gets called when change to new state. 
    /// Pass in controller to make changes to FarmPlot
    /// </summary>
    /// <param name="controller">the controller for farm object</param>
    void Handle(FarmController controller);
}
