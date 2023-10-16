using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController controller;

    [SerializeField]
    private float speed;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    } //awake

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, 0f, z);

        controller.Move(move.normalized * speed * Time.deltaTime);

        if(transform.position.y > 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }

    } //update

}
