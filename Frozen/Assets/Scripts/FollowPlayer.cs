using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 positionOffset;

    Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    } //awake

    private void LateUpdate()
    {
        transform.position = player.position + positionOffset;
    } //late update

}
