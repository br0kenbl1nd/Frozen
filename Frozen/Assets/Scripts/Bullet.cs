using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float damage;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private float range;
    float travelTime;
    float travelTimeCount;

    public string obstacleTag = "Obstacle";

    public string enemyTag = "Enemy";

    public string fortTag = "Fort";

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

    private void OnTriggerEnter(Collider other)
    {       

        if(other.gameObject.CompareTag(obstacleTag))
        {
            Debug.Log("We hit an obstacle!");
            //destroy the obstacle and give rewards
            Health _obstacleHealth = other.gameObject.GetComponent<Health>();
            if(_obstacleHealth != null)
            {
                _obstacleHealth.TakeDamage(damage);
            }
            

            Destroy(gameObject);
        }

        if(other.gameObject.CompareTag(enemyTag))
        {
            Debug.Log("We hit an enemy!");
            //destroy the enemy and give rewards
            Health _enemyHealth = other.gameObject.GetComponent<Health>();
            if (_enemyHealth != null)
            {
                _enemyHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag(fortTag))
        {
            Debug.Log("We hit the fort!");
            //destroy the enemy and give rewards
            Health _fortHealth = other.gameObject.GetComponent<Health>();
            if (_fortHealth != null)
            {
                _fortHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

    }

} //class
