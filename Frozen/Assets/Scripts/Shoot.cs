using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float fireRate;
    private float fireRateCount;

    public Transform firePoint;


    private void Start()
    {
        fireRateCount = 0f;
    } //start

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (fireRateCount <= 0f)
            {
                ShootBullet();
                fireRateCount = 1f / fireRate;
            }
        }

        fireRateCount -= Time.deltaTime;

    } //update

    void ShootBullet()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    } //shoot

} //class
