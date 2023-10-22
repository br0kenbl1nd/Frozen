using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField]
    private float startHealth;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = startHealth;
    } //awake

    private void Update()
    {
        if(currentHealth <= 0f)
        {
            //the unit is killed
            Debug.Log("The " + gameObject.name + " is killed!");

            Destroy(gameObject);

        }
    } //update

    public void TakeDamage(float _amount)
    {
        currentHealth -= _amount;
    } //take damage

} //class
