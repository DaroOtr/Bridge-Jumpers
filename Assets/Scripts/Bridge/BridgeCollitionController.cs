using UnityEngine;

public class BridgeCollitionController : MonoBehaviour
{
    [SerializeField] private int points;
    [SerializeField] private bool isMovementTrigger;
    [SerializeField] private BridgeController _bridge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isMovementTrigger)
                _bridge.canMove = true;
            else
                GameManager.instance.AddScore(points);


            Destroy(this);
        }
    }
}