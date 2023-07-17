using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCarWaypoint : MonoBehaviour
{
    [Header("Opponent Car")]
    public OpponentCar opponentCar;
    public Waypoint currnetWaypoint;

    private void Awake()
    {
        opponentCar = GetComponent<OpponentCar>();
    }
    private void Start()
    {
        opponentCar.LocalDestination(currnetWaypoint.Getposition());
    }

    private void Update()
    {
        if(opponentCar.destinationReached)
        {
            currnetWaypoint  = currnetWaypoint.nextWaypoint;
            opponentCar.LocalDestination(currnetWaypoint.Getposition());
        }
    }
}
