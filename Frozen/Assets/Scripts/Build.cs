using UnityEngine;

public class Build : MonoBehaviour
{
    [Header("Building to build")]
    [SerializeField]
    private GameObject basicObstacle;
    [SerializeField]
    private float buildFuelRequired;

    [Header("Build fuel")]
    [SerializeField]
    private float startBuildFuel;
    private float buildFuel;

    [Header("Check building component of the player")]
    public CheckBuilding checkBuilding;

    private void Awake()
    {
        buildFuel = startBuildFuel;
    } //awake

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(checkBuilding != null)
            {
                if(checkBuilding.Obstruction == null)
                {
                    if (buildFuel > 0)
                    {
                        BuildBasicObstacle();
                        LoseBuildFuel(buildFuelRequired);
                    }
                    else
                    {
                        Debug.Log("No build fuel");
                    }
                }
            }
        }
        
    } //update

    private void BuildBasicObstacle()
    {
        Instantiate(basicObstacle, checkBuilding.gameObject.transform.position, Quaternion.identity);
    } //build basic building

    public void GainBuildFuel(float _amount)
    {
        buildFuel += _amount;
        if(buildFuel > startBuildFuel)
        {
            buildFuel = startBuildFuel;
        }
    } // gain build fuel

    public void LoseBuildFuel(float _amount)
    {
        buildFuel -= _amount;
        if(buildFuel < 0)
        {
            buildFuel = 0;
        }
    } // lose build fuel

} //classs
