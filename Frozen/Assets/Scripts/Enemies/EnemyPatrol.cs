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

    [Header("Enemy Obstacle tag")]
    [SerializeField]
    private string enemyObstacleTag;

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
                List<Vector3> _pointsToBuild = ChoosePointsToBuild(currentBuildRadius);
                //check if there are buildings existing in the points
                foreach(Vector3 _pointToBuild in _pointsToBuild)
                {
                    if(CheckIfBuildingInSpot(_pointToBuild))
                    {
                        _pointsToBuild.Remove(_pointToBuild);
                    }
                }
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
            float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
            if(distanceToPlayer <= searchPlayerRange)
            {
                isPlayerInRange = true;
            }
            else
            {
                isPlayerInRange = false;
            }
        }

    } //check for players in range

    List<Vector3> ChoosePointsToBuild(float buildRadius)
    {
        List<Vector3> _pointsToBuild = new List<Vector3>();

        float _noOfPoints = (buildRadius * 2) + 1;
        for(int i = 0; i < _noOfPoints; i++)
        {
            if (i / buildRadius <= 1)
            {
                float _xPos = (fortPosition.position.x - buildRadius) + i;
                float _zPos = (fortPosition.position.z) - i;
                _pointsToBuild.Add(new Vector3(_xPos, 0f, _zPos));
            }
            else
            {
                float _xPos = (fortPosition.position.x - buildRadius) + i;
                float _zPos = (fortPosition.position.z - ((buildRadius + 1) - i));
                _pointsToBuild.Add(new Vector3(_xPos, 0f, _zPos));
            }
        }


        return _pointsToBuild;
    } //choose points to build

    bool CheckIfBuildingInSpot(Vector3 _position)
    {
        GameObject[] _obs = GameObject.FindGameObjectsWithTag(enemyObstacleTag);
        int n = 0;
        foreach(GameObject _ob in _obs)
        {
            if(_ob.transform.position == _position)
            {
                n += 1;
            }
        }

        if(n == 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    } //check if building in spot

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, searchPlayerRange);
    } // on draw gizmo selected

} //class
