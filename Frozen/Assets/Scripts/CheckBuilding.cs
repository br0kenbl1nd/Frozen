using UnityEngine;

public class CheckBuilding : MonoBehaviour
{

    private GameObject obstruction;
    public GameObject Obstruction
    {
        get { return obstruction; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fort")
        {
            obstruction = other.gameObject;
            Debug.Log(other.gameObject.name);
        }

        if (other.gameObject.tag == "Obstacle")
        {
            obstruction = other.gameObject;
            Debug.Log(other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        obstruction = null;
    }

} //class
