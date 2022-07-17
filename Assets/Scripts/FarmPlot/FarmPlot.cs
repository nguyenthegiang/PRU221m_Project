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

    //Type of Plant in this FarmPlot (will make this FarmPlot appear differently when Ripe
    public Plant plant;

    void Start()
    {
        //instantiate farm controller
        _farmController = GetComponent<FarmController>();
    }

    //(For Farmer to call) [Client] call to method of Controller to change state
    //Specify the type of Plant to seed
    public void FarmSeed(Plant plant)
    {
        this.plant = plant;
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
        //pass in the type of Plant to make the Plot look different with each type of Plant
        _farmController.FarmRipe(plant);
    }

    //(For Farmer to call) [Client] call to method of Controller to change state
    public void FarmHarvest()
    {
        _farmController.FarmHarvest();
    }
}
