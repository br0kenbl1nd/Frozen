using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private float range;
    float travelTime;
    float travelTimeCount;

    private void Awake()
    {
        travelTime = range / bulletSpeed;
    } //awake

    private void Update()
    {
        transform.Translate(transform.forward * bulletSpeed * Time.deltaTime, Space.World);

        travelTimeCount += Time.deltaTime;

        if(travelTimeCount >= travelTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "trigger");
    }

} //class
