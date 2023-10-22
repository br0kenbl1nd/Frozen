using UnityEngine;
using System.Collections.Generic;

public class EnemyPatrol : MonoBehaviour
{

    //patrol enemies should be patroling by default
    //they should chase the player when the player hits their rader

    [Header("Players search range for patrolling enemies")]
    [SerializeField]
    private float searchPlayerRange;
    private bool isPlayerInRange;
    [Header("Player Tag")]
    public string playerTag = "Player";

    private bool isPatrolRound;

    [Header("Initial Build radius")]
    [SerializeField]
    private float initialBuildRadius;
    private float currentBuildRadius;

    //fort position
    private Transform fortPosition;

    private void Awake()
    {
        isPatrolRound = false;
        currentBuildRadius = initialBuildRadius;

        fortPosition = GameObject.FindGameObjectWithTag("Fort").transform;

    } //start

    private void Update()
    {
        //check for player in their ranges
        CheckForPlayersInRange();

        if(isPlayerInRange == true)
        {
            //chase the player

        }
        else
        {
            //Patrol the area
            //The enemy unit should build one round and patrol one round
            //The enemy unit should check for existing buildings in the area
            //first round should be build round
            if(isPatrolRound == false)
            {
                //choose points to build
                ChoosePointsToBuild(currentBuildRadius);
                //check if there are buildings existing in the points
                //select first point
                //move to the first point
                //build in the first point
                //check for buildings and select the second point
                //continue the loop
            }

        }

    } //update

    void CheckForPlayersInRange()
    {
        GameObject[] _players = GameObject.FindGameObjectsWithTag(playerTag);
        foreach(GameObject _player in _players)
        {
            if(_player.CompareTag(playerTag))
            {
                isPlayerInRange = true;
            }
            else
            {
                isPlayerInRange = false;
            }
        }

    } //check for players in range

    List<Transform> ChoosePointsToBuild(float buildRadius)
    {
        List<Transform> _pointsToBuild = new List<Transform>();

        int _noOfPoints = (int)(buildRadius * 2) + 1;
        for(int i = 0; i < _noOfPoints; i++)
        {

        }


        return _pointsToBuild;
    } //choose points to build

} //class
