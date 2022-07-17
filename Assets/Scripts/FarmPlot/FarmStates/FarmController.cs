using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [State Deisgn Pattern: Farm]
/// Controlling all the states using Context
/// </summary>
public class FarmController : MonoBehaviour
{
    //Different Sprites for each state to use
    public Sprite EmptyPlotSprite;  //dat trong
    public Sprite SeedPlotSprite;   //gieo hat
    public Sprite WaterPlotSprite;  //nay mam
    public Sprite RipePlotSprite;   //chin

    //Different types of Plant Sprite
    public Sprite PumpkinRipePlotSprite;    //bi ngo
    public Sprite CarrotRipePlotSprite;     //ca rot
    public Sprite RiceRipePlotSprite;       //lua
    public Sprite SunflowerRipePlotSprite;  //hoa huong duong

    //for States to change Sprite of GameObject
    public SpriteRenderer SpriteRenderer;

    // states of farm
    private IFarmState _farmSeedState, _farmWaterState, _farmRipeState, _farmHarvestState;

    //context class
    public FarmStateContext _farmStateContext;

    void Awake()
    {
        //instantiate spriteRenderer
        SpriteRenderer = GetComponent<SpriteRenderer>();

        //init state context and farm states
        _farmStateContext = new FarmStateContext(this);
        //assign farm states to gameObject
        _farmSeedState = gameObject.AddComponent<FarmSeedState>();
        _farmWaterState = gameObject.AddComponent<FarmWaterState>();
        _farmRipeState = gameObject.AddComponent<FarmRipeState>();
        _farmHarvestState = gameObject.AddComponent<FarmHarvestState>();

        //set default state
        _farmStateContext.CurrentState = _farmHarvestState;
    }

    //change to Seed State
    public void FarmSeed()
    {
        _farmStateContext.Transition(_farmSeedState);
    }

    //change to Water State
    public void FarmWater()
    {
        _farmStateContext.Transition(_farmWaterState);
    }

    //change to Ripe State
    public void FarmRipe(Plant plant)
    {
        //depend on type of Plant -> has different Sprite of Ripe State
        //-> change RipePlotSprite accordingly
        switch (plant)
        {
            case Plant.Carrot:
                {
                    RipePlotSprite = CarrotRipePlotSprite;
                    break;
                }
            case Plant.Pumpkin:
                {
                    RipePlotSprite = PumpkinRipePlotSprite;
                    break;
                }
            case Plant.Rice:
                {
                    RipePlotSprite = RiceRipePlotSprite;
                    break;
                }
            case Plant.Sunflower:
                {
                    RipePlotSprite = SunflowerRipePlotSprite;
                    break;
                }
            default:
                break;
        }

        _farmStateContext.Transition(_farmRipeState);
    }

    //change to Harvest State
    public void FarmHarvest()
    {
        _farmStateContext.Transition(_farmHarvestState);
    }
}
