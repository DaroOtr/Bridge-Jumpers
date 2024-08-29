using UnityEngine;
using UnityEngine.Events;

public class BridgeController : MonoBehaviour, IProduct
{
    [SerializeField] private string productName = "BridgeController";
    [SerializeField] private BridgeController[] possibleNeighbors;

    public string ProductName
    {
        get => productName;
        set => productName = value;
    }

    private ParticleSystem particleSystem;
    [SerializeField] private BridgePart bridgeHalfL;
    [SerializeField] private BridgePart bridgeHalfR;
    [SerializeField] private Transform SpawnLeftPart;
    [SerializeField] private Transform SpawnRightPart;
    [SerializeField] private float Speed;
    public bool canMove;

    public UnityEvent<BridgeController> OnDestroyBridge;

    private void OnEnable()
    {
        bridgeHalfL.transform.position = SpawnLeftPart.position;
        bridgeHalfL.BridgePartReset();
        bridgeHalfR.transform.position = SpawnRightPart.position;
        bridgeHalfR.BridgePartReset();
    }

    private void FixedUpdate()
    {
        if (canMove)
            moveBridge();
    }

    private void moveBridge()
    {
        if (bridgeHalfL.IsColliding)
        {
            bridgeHalfL.transform.position = bridgeHalfL.transform.position;
        }
        else
        {
            bridgeHalfL._rigidbody.AddForce(new Vector3(Speed, 0.0f), ForceMode.Force);
        }

        if (bridgeHalfR.IsColliding)
        {
            bridgeHalfR.transform.position = bridgeHalfR.transform.position;
        }
        else
        {
            bridgeHalfR._rigidbody.AddForce(new Vector3(-Speed, 0.0f), ForceMode.Force);
        }
    }

    public BridgeController[] GetPossibleNeighbors() { return possibleNeighbors; }

    public void Initialize()
    {
        // any unique logic to this product
        gameObject.name = productName;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem?.Stop();
        particleSystem?.Play();
    }
}