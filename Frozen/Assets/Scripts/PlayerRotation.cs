using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Transform gfx;

    [SerializeField]
    private float rotationSpeed;

    #endregion

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        float z = Input.GetAxisRaw("Vertical");

        Vector3 movementDir = new Vector3(x, 0f, z);

        movementDir.Normalize();

        if(movementDir != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(movementDir, Vector3.up);

            gfx.rotation = Quaternion.RotateTowards(gfx.rotation, toRotate, rotationSpeed * Time.deltaTime);

        }

    } //update

} //class
