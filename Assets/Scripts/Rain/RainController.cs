using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Library
using UnityEngine.Pool;

/// <summary>
/// [Object Pool Pattern - Client (using the Pool)]
/// Control the Rain: Make it Rain every 10 seconds
/// </summary>
public class RainController : MonoBehaviour
{
    //for creating the PooledObject
    [SerializeField]
    RainDrop rainDropPrefab;

    //Pool from Unity
    ObjectPool<RainDrop> pool;

    //Control time between 2 rains
    const float rainDelaySeconds = 10f;
    Timer rainTimer;

    //amount of rainDrop every time it rains
    [SerializeField]
    float rainDropAmount = 50;

    // Start is called before the first frame update
    void Start()
    {
        //create the Pool
        pool = new ObjectPool<RainDrop>(
            () =>
            {
                /*create function: 
                 * called when there're no objects available in Pool
                 * -> need to create one
                 */
                return Instantiate(rainDropPrefab);
            },
            bullet =>
            {
                /*onGet function: 
                 * when we ask for 1 object, and there is 1 available in Pool
                 * -> returns an object
                 */
                //active it
                bullet.gameObject.SetActive(true);
            },
            bullet =>
            {
                /*onRelease function:
                 * when we're done with the object -> give it back to the Pool
                 */
                //deactive it
                bullet.gameObject.SetActive(false);
            },
            bullet =>
            {
                /*destroy action:
                 * this pool will always spawn objects when we ask for them, even
                 * if it's above the Maximum. Once we spawn it, and it goes to to
                 * return to the pool, if the pool is already filled
                 * => it will destroy the object instead
                 */
                Destroy(bullet.gameObject);
            },
            //not important 
            false,
            //default capacity
            50,
            //max size
            90
        );

        //create and start Timer
        rainTimer = gameObject.AddComponent<Timer>();
        rainTimer.Duration = rainDelaySeconds;
        rainTimer.Run();
    }

    void Update()
    {
        //make the rain every 2 seconds
        if (rainTimer.Finished)
        {
            MakeRain();
            rainTimer.Duration = rainDelaySeconds;
            rainTimer.Run();
        }
    }

    //Make the Rain by spawning a large amount of rainDrop in Map
    private void MakeRain()
    {
        for (int i = 0; i < rainDropAmount; i++)
        {
            CreateRainDrop();
        }
    }

    //Create a RainDrop with Pool
    //Create in a random location in Map
    private void CreateRainDrop()
    {
        RainDrop rainDrop = pool.Get();
        //make a random position in Map for the RainDrop
        rainDrop.transform.position = new Vector3(Random.Range(-9f, 9f), Random.Range(-5f, 5f), 0);
        rainDrop.transform.rotation = Quaternion.identity;
        rainDrop.Init(killAction);
    }

    //method to destroy rainDrop, to pass in the RainDrop Script
    private void killAction(RainDrop rainDrop)
    {
        //using Pool
        pool.Release(rainDrop);
    }
}
