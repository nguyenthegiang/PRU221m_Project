using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Client using the {FarmPlot} to control it
/// Guide: Stand next to the Farm Plot you want to control
///     - Sow: 
///         + Carrot: Press J
///         + Pumpkin: Press U
///         + Rice: Press I
///         + Sunflower: Press O
///     - Water: Press K
///     - Harvest: Press L
/// </summary>
public class Farmer : MonoBehaviour
{
    //list of FarmPlot to control
    List<FarmPlot> farmPlots;

    void Start()
    {
        //find all FarmPlots in Map
        farmPlots = new List<FarmPlot>();
        GameObject[] farmPlotObjects = GameObject.FindGameObjectsWithTag("FarmPlot");
        foreach (GameObject farmPlotObject in farmPlotObjects)
        {
            farmPlots.Add(farmPlotObject.GetComponent<FarmPlot>());
        }
    }

    void Update()
    {
        //Farm Seed: Carrot
        if (Input.GetKeyUp(KeyCode.J))
        {
            /*Find closest FarmPlot to the Main Character to perform action to*/
            FarmPlot actionFarmPlot = findClosestFarmPlot(transform.position);
            actionFarmPlot.FarmSeed(Plant.Carrot);
        }
        //Farm Seed: Pumpkin
        else if (Input.GetKeyUp(KeyCode.U))
        {
            /*Find closest FarmPlot to the Main Character to perform action to*/
            FarmPlot actionFarmPlot = findClosestFarmPlot(transform.position);
            actionFarmPlot.FarmSeed(Plant.Pumpkin);
        }
        //Farm Seed: Rice
        else if (Input.GetKeyUp(KeyCode.I))
        {
            /*Find closest FarmPlot to the Main Character to perform action to*/
            FarmPlot actionFarmPlot = findClosestFarmPlot(transform.position);
            actionFarmPlot.FarmSeed(Plant.Rice);
        }
        //Farm Seed: Sunflower
        else if (Input.GetKeyUp(KeyCode.O))
        {
            /*Find closest FarmPlot to the Main Character to perform action to*/
            FarmPlot actionFarmPlot = findClosestFarmPlot(transform.position);
            actionFarmPlot.FarmSeed(Plant.Sunflower);
        }
        //Farm Water
        else if (Input.GetKeyUp(KeyCode.K))
        {
            /*Find closest FarmPlot to the Main Character to perform action to*/
            FarmPlot actionFarmPlot = findClosestFarmPlot(transform.position);
            actionFarmPlot.FarmWater();
        }
        //Farm Harvest
        else if (Input.GetKeyUp(KeyCode.L))
        {
            /*Find closest FarmPlot to the Main Character to perform action to*/
            FarmPlot actionFarmPlot = findClosestFarmPlot(transform.position);
            actionFarmPlot.FarmHarvest();
        }
    }

    //Find closest FarmPlot to a position
    private FarmPlot findClosestFarmPlot(Vector3 position)
    {
        float shortestDistance = float.MaxValue;
        FarmPlot closestFarmPlot = null;
        foreach (FarmPlot farmPlot in farmPlots)
        {
            float distanceToOject = Vector3.Distance(position, farmPlot.gameObject.transform.position);
            if (distanceToOject < shortestDistance)
            {
                shortestDistance = distanceToOject;
                closestFarmPlot = farmPlot;
            }
        }

        return closestFarmPlot;
    }
}
