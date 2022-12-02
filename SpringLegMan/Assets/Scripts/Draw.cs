using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Draw : MonoBehaviour
{
    enum State
    {
        preGame,

        inGame,

        finishGame,

        failGame,

    }
    public GameObject linePrefab;
    public GameObject planePrefab;
    public GameObject line;
    public LineRenderer lineRenderer;
   // public EdgeCollider2D edgeCollider;

    public  BoxCollider edgeCollider;

    public List<Vector2> fingerPosList;
    private State _currentState = State.preGame;
    private int count;
    private Vector3 planePos;

    public Character character;
    void Start()
    {
        character = FindObjectOfType<Character>();
        GameManager.instance.startPanel.SetActive(true);

        Time.timeScale = 0;
    }


    void Update()
    {
        switch (_currentState)
        {
            case State.preGame:
                if (Input.GetMouseButtonDown(0))
                {
                    Time.timeScale = 1;
                    GameManager.instance.startPanel.SetActive(false);
                    GameManager.instance.startPanel.transform.DOScale(new Vector3(0, 90, 0), 2f).SetLoops(-1, LoopType.Yoyo);
                    _currentState = State.inGame;


                }

                break;

            case State.inGame:

              

                if (Input.GetMouseButtonDown(0))
                {
                    Drawing();
                }
                if (Input.GetMouseButton(0))
                {
                    Vector2 fingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if(Vector2.Distance(fingerPos, fingerPosList[^1]) > 0.1f)    // parmak pos ile son parmak pos 0.1f ten büyükse 
                    {
                        LineUpdate(fingerPos);
                        planePos = new Vector3(fingerPos.x, fingerPos.y, 0);
                    }
                }
                break;

        }
        void Drawing()
        {
            line = Instantiate(planePrefab, /*Vector3.zero*/planePos, Quaternion.identity);
            //line = Instantiate(linePrefab, /*Vector3.zero*/planePos, Quaternion.identity);
            lineRenderer = line.GetComponent<LineRenderer>();
           // edgeCollider = line.GetComponent<EdgeCollider2D>();
           // edgeCollider = line.GetComponent<BoxCollider>();
            fingerPosList.Clear(); // 2.çizgiye geçerken sıfırlamak için
            fingerPosList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            fingerPosList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition)); // componentler çift yönlü olduğu için
            lineRenderer.SetPosition(0, fingerPosList[0]); // başlangıç ve sonu 
            lineRenderer.SetPosition(1, fingerPosList[1]);
            // edgeCollider.points = fingerPosList.ToArray();
        }

        void LineUpdate(Vector2 incomingFingerPos)
        {
            fingerPosList.Add(incomingFingerPos);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, incomingFingerPos);
           // edgeCollider.points = fingerPosList.ToArray();
        }
    }
}
