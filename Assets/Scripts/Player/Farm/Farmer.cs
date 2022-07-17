using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Client using the {FarmPlot} to control it
/// Guide:
///     - Farm Seed: Press J
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
        foreach(GameObject farmPlotObject in farmPlotObjects)
        {
            farmPlots.Add(farmPlotObject.GetComponent<FarmPlot>());
        }
    }

    void Update()
    {
        //Farm Seed
        if (Input.GetKeyUp(KeyCode.J))
        {
            /*Find closest FarmPlot to the Main Character to perform action to*/
            FarmPlot actionFarmPlot = findClosestFarmPlot(transform.position);
            actionFarmPlot.FarmSeed();
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
