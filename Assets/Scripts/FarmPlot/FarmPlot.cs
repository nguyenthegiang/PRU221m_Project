using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [State Deisgn Pattern - Client: Farm]
/// Control the Farm Plot;
/// For Farmer to call
/// </summary>
public class FarmPlot : MonoBehaviour
{
    //For controlling Farm State of Farm Plot
    private FarmController _farmController;

    void Start()
    {
        //instantiate farm controller
        _farmController = GetComponent<FarmController>();
    }

    //(For Farmer to call) [Client] call to method of Controller to change state
    public void FarmSeed()
    {
        _farmController.FarmSeed();
    }

    //(For Farmer to call) [Client] call to method of Controller to change state
    public void FarmWater()
    {
        _farmController.FarmWater();
    }

    //(For this class to call) [Client] call to method of Controller to change state
    public void FarmRipe()
    {
        _farmController.FarmRipe();
    }

    //(For Farmer to call) [Client] call to method of Controller to change state
    public void FarmHarvest()
    {
        _farmController.FarmHarvest();
    }
}
