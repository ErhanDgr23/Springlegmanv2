using UnityEngine;
using System.Collections;
using DG.Tweening;
public class DrawLine : MonoBehaviour
{
    enum State
    {
        preGame,

        inGame,

        finishGame,

        failGame,

    }
    private State _currentState = State.preGame;
    private int count;
    private LineRenderer line; // Reference to LineRenderer
    private Vector3 mousePos;
    private Vector3 startPos;    // Start position of line
    private Vector3 endPos;    // End position of line
    private int Count;
    public Material mat;
    public float charSpeed;
    public Rigidbody rb;
    private Crab crapScript;
    public bool oyunbasladi;

    private void Start()
    {
        crapScript = FindObjectOfType<Crab>();
        GameManager.instance.startPanel.SetActive(true);
        rb.useGravity = false;
        charSpeed = 0;


    }
    void Update()
    {
        switch (_currentState)
        {
            case State.preGame:
                if (Input.GetMouseButtonDown(0))
                {

                    GameManager.instance.startPanel.SetActive(false);
                    // GameManager.instance.startPanel.transform.DOScale(new Vector3(0, 90, 0), 2f).SetLoops(-1, LoopType.Yoyo);
                    if (Count == 0)
                    {
                        charSpeed = 50f;

                        //rb.AddForce(Vector3.up * charSpeed * Time.deltaTime, ForceMode.Impulse);
                        rb.velocity = Vector3.up * charSpeed * Time.deltaTime;
                        Count++;
                    }
                    _currentState = State.inGame;
                }

                break;

            case State.inGame:

                oyunbasladi = true;
                rb.useGravity = true;
                Vector3 mouseposy = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (mouseposy.y < rb.transform.position.y)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (line == null)
                            createLine();

                        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        mousePos.z = 0;
                        line.SetPosition(0, mousePos);
                        startPos = mousePos;
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        if (line)
                        {
                            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            mousePos.z = 0;
                            line.SetPosition(1, mousePos);
                            endPos = mousePos;
                            addColliderToLine();
                            line = null;
                        }
                    }
                    else if (Input.GetMouseButton(0))
                    {
                        if (line)
                        {
                            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            mousePos.z = 0;
                            line.SetPosition(1, mousePos);
                        }
                    }
                }
                // On mouse down new line will be created 


                break;
        }
    }


    // Following method creates line runtime using Line Renderer component
    [System.Obsolete]
    private void createLine()
    {
        line = new GameObject("Line").AddComponent<LineRenderer>();
        line.material = mat;
        line.SetVertexCount(2);
        line.SetWidth(0.1f, 0.1f);
        line.SetColors(Color.black, Color.black);
        line.useWorldSpace = true;
    }
    // Following method adds collider to created line
    private void addColliderToLine()
    {
        BoxCollider col = new GameObject("Collider").AddComponent<BoxCollider>();
        Rigidbody rb = col.gameObject.AddComponent<Rigidbody>();
        col.tag = "Line";
        col.transform.parent = line.transform; // Collider is added as child object of line
        rb.constraints = RigidbodyConstraints.FreezePosition;
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
        //rb.transform.parent = line.transform;
        float lineLength = Vector3.Distance(startPos, endPos); // length of line
        col.size = new Vector3(lineLength, 0.1f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
        Vector3 midPoint = (startPos + endPos) / 2;
        col.transform.position = midPoint; // setting position of collider object
                                           // Following lines calculate the angle between startPos and endPos
        float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
        if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
        {
            angle *= -1;
        }
        angle = Mathf.Rad2Deg * Mathf.Atan(angle);
        col.transform.Rotate(0, 0, angle);
    }
}

