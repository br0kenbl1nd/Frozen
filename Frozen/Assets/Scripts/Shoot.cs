using UnityEngine;

public class Shoot : MonoBehaviour
{

    [Header("Bullet type")]
    [SerializeField]
    private GameObject bullet;

    [Header("Attack speed")]
    [SerializeField]
    private float fireRate;
    private float fireRateCount;

    [Header("Ammo")]
    [SerializeField]
    private int startAmmo;
    private int currentAmmo;

    public Transform firePoint;


    private void Start()
    {
        fireRateCount = 0f;
        currentAmmo = startAmmo;
    } //start

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (fireRateCount <= 0f)
            {
                if (currentAmmo > 0)
                {
                    ShootBullet();
                    fireRateCount = 1f / fireRate;
                }
                else
                {
                    Debug.Log("No ammo");
                }
            }
        }

        fireRateCount -= Time.deltaTime;

    } //update

    void ShootBullet()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        LoseAmmo(1);
    } //shoot

    public void GainAmmo(int _amount)
    {
        currentAmmo += _amount;
        if(currentAmmo > startAmmo)
        {
            currentAmmo = startAmmo;
        }
    } //gain ammo

    public void LoseAmmo(int _amount)
    {
        currentAmmo -= _amount;
        if(currentAmmo <= 0)
        {
            currentAmmo = 0;
        }
    } // lose ammo

} //class
