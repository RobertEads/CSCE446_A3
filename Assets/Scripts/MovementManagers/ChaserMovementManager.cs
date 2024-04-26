using UnityEngine;

public class ChaserMovementManager : MonoBehaviour
{
    private bool isMoving = false;
    private float gridSizeConstant = 3.5f; //Works for maze scale - Vector3(1.75018144,1.75018144,1.75018144)
    private int xDirectionFactor = 1;
    private int zDirectionFactor = 1;
    
    private Vector3 newPosition = Vector3.zero;
    private PlayerPathTracker playerPathTracker_script;
    private GameObject MazeTrackingAnchor;

    [SerializeField] private float movementSpeed = 2.5f;
    [SerializeField] private bool reverseFozwardX = false;
    [SerializeField] private bool reverseForwardZ = true;


    void Start()
    {
        GameObject playerPathTracker_object = GameObject.Find("pathTracker_player");
        playerPathTracker_script = playerPathTracker_object.GetComponent<PlayerPathTracker>();
        MazeTrackingAnchor = GameObject.Find("MazeTrackingAnchor");

        if (reverseFozwardX) { xDirectionFactor = -1; }
        if (reverseForwardZ) { zDirectionFactor = -1; }

        Invoke("startChasing", 3f);
    }

    void Update()
    {
        float step = movementSpeed * Time.deltaTime;
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
            if (isEqual(transform.position.x, newPosition.x) && isEqual(transform.position.z, newPosition.z))
            {
                isMoving = false;
                if (!playerPathTracker_script.isPathEmpty()) { startChasing(); }
            }
        }
    }

    private void startChasing()
    {
        int nextSquareId = (int) playerPathTracker_script.dequeue_mazeId();
        int gridX = nextSquareId / 25;
        int gridZ = nextSquareId % 25;
        newPosition = MazeTrackingAnchor.transform.position + new Vector3(xDirectionFactor * gridSizeConstant * gridX, 0f, zDirectionFactor * gridSizeConstant * gridZ);
        isMoving = true;
    }

    private bool isEqual(float a, float b)
    {
        float Epsilon = 0.1f;
        if (a >= b - Epsilon && a <= b + Epsilon) { return true; }
        else { return false; }
    }

    public void updateChaserPosition(int newNodeId) { playerPathTracker_script.updateChaserPosition(newNodeId); }
}
