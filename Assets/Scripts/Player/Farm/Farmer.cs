using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Client using the {FarmPlot} to control it
/// Guide: Stand next to the Farm Plot you want to control
///     - Sow: Press J
///     - Water: Press K
///     - Harvest: Press L
///     
/// [Queue - Client]: Using the Queue to control the list of Seeds the User has:
///     - When user buys a new Seed => Enqueue
///     - When user plant a Seed => Dequeue
///     => Always use the oldest Seed to plant
/// </summary>
public class Farmer : MonoBehaviour
{
    //List of FarmPlot to control
    List<FarmPlot> farmPlots;

    //Amount of Money the User has
    //Capital: 50$
    public int Money = 50;

    //A Queue that contains all the Seeds that User has
    public Queue<Plant> seeds = new Queue<Plant>();

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
        //---------------------Farm--------------------
        //Farm Seed
        if (Input.GetKeyUp(KeyCode.J))
        {
            /*Find closest FarmPlot to the Main Character to perform action to*/
            FarmPlot actionFarmPlot = findClosestFarmPlot(transform.position);
            //Take a Seed from the Queue to Farm
            try
            {
                actionFarmPlot.FarmSeed(seeds.Dequeue());
            } catch (Exception)
            {
                //alert: if there are no Seed in Queue
                print("Don't have any Seed to Farm");
            }
            
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
            //Add to the Money of User the Amount of money received after harvesting the farm plot
            Money += actionFarmPlot.FarmHarvest();
        }

        //--------------------Buy Seed--------------------
        //Buy Seed: Carrot - Cost: 10$
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            //Not allow buying if don't have enough money
            if (Money - 10 < 0)
            {
                //alert
                print("Not enough money!");
            } else
            {
                //Add seed to Queue
                seeds.Enqueue(Plant.Carrot);
                //Subtract Money
                Money -= 10;
            }
        }
        //Buy Seed: Pumpkin - Cost: 20$
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            //Not allow buying if don't have enough money
            if (Money - 20 < 0)
            {
                //alert
                print("Not enough money!");
            }
            else
            {
                //Add seed to Queue
                seeds.Enqueue(Plant.Pumpkin);
                //Subtract Money
                Money -= 20;
            }
        }
        //Buy Seed: Rice - Cost: 30$
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            //Not allow buying if don't have enough money
            if (Money - 30 < 0)
            {
                //alert
                print("Not enough money!");
            }
            else
            {
                //Add seed to Queue
                seeds.Enqueue(Plant.Rice);
                //Subtract Money
                Money -= 30;
            }
        }
        //Buy Seed: Sunflower - Cost: 40$
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            //Not allow buying if don't have enough money
            if (Money - 40 < 0)
            {
                //alert
                print("Not enough money!");
            }
            else
            {
                //Add seed to Queue
                seeds.Enqueue(Plant.Sunflower);
                //Subtract Money
                Money -= 40;
            }
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
