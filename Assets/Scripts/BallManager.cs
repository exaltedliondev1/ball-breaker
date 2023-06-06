using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BallManager : MonoBehaviour
{

    public static BallManager Instance;
    [SerializeField] private GameObject[] balls;
  //[SerializeField] List<GameObject> balls = new List<GameObject>();
    [SerializeField] public int noOfBalls = 5;
    [SerializeField] public int addBall;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] public GameObject spawnPos;
    [SerializeField] private float speed = 70f;
    public float delay = 0.2f;
    public int detectBall;
    public Transform Arrow;
    public bool clickEnable = true;
    public GameObject ballText;
    public int ballScore;
   
        
    
   
    public LineRenderer lineRenderer1;
    public LineRenderer lineRenderer2;
    private Ray2D ray;
    private RaycastHit2D hit;
    public float length = 3f;
    Vector2 reflection;

    private void Awake()
    {
        Instance = this;
        
    }




    void Start()
    {

        SetUpBalls();
        SetUpScoreText(noOfBalls);
        lineRenderer1.enabled = false;
        lineRenderer2.enabled = false;
        
    }




    void Update()
    {
        ArrowRotation();
        BallMovement();
       
    }






    void BallMovement()
    {
        if (Input.GetMouseButtonUp(0) && clickEnable == true)
        {
            SetNoOfBalls();
            lineRenderer1.enabled = false;
            lineRenderer2.enabled = false;

            clickEnable = false;
            spawnPos.SetActive(false);
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 moveDirection = (clickPosition - (Vector2)spawnPos.transform.position).normalized;
            for (int i = 0; i < noOfBalls; i++)
            {
                GameObject ball = Instantiate(ballPrefab, spawnPos.transform.position, Quaternion.identity);
                balls[i] = ball;
                
            }
            StartCoroutine(MoveBall(moveDirection));
        }
    }

    void ArrowRotation()
    {
        if (Input.GetMouseButton(0)&& clickEnable==true)
        {
            Vector3 heldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPos.transform.LookAt(heldPosition, new Vector3(0, 0, 1));
            Arrow.transform.LookAt(heldPosition, new Vector3(0, 0, 1));
           
            GenerateLine();
           
        }
    }

    IEnumerator MoveBall(Vector2 moveDirection)
    {
        for (int i = 0; i < noOfBalls; i++)
        {
            Vector2 direction = moveDirection*speed;
            if (balls[i] != null)
            {
                Ball balli = balls[i].GetComponent<Ball>();
                if (balli != null)
                {
                    balli.VelocityOnClick(direction);
                }

                ballScore--;
                if (ballScore == 0)
                {
                    ballText.SetActive(false);
                }
                SetUpScoreText(ballScore);
                yield return new WaitForSeconds(delay);
            }
        }


    }

    public void SetSpawnPosition(GameObject BallObject)
    {
        if (detectBall == 1)
        {
            spawnPos.SetActive(true);
            spawnPos.transform.position = BallObject.transform.position;
            ballText.transform.position = BallObject.transform.position + new Vector3(0.2f, 0.3f, 0);
            Arrow.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        else if (detectBall == noOfBalls)
        {

            SetUpBalls();
            ballScore = detectBall;
            SetUpScoreText(ballScore);
            detectBall = 0;
            clickEnable = true;
            ballText.SetActive(true);
        }
    }

    public void SetUpBalls()
    {
        balls = new GameObject[noOfBalls];
    }

    public void MoveTowardSpawn(GameObject ball)
    {
        ball.transform.Translate(spawnPos.transform.position * 5 * Time.deltaTime);
    }
    public void SetUpScoreText(int noOfBalls)
    {
        TextMesh Text = ballText.GetComponent<TextMesh>();
        Text.text = "x" + " " + noOfBalls.ToString();
        ballScore = noOfBalls;
    }


    void GenerateLine()
    {
        
        hit = Physics2D.Raycast(spawnPos.transform.position, spawnPos.transform.up);

        Vector2 pt1 = spawnPos.transform.position + spawnPos.transform.up;
        if (hit.collider != null)
        {

         

            reflection = Vector2.Reflect(spawnPos.transform.up, hit.normal);
            lineRenderer1.enabled = true;
            lineRenderer1.positionCount = 1;
            lineRenderer1.SetPosition(0, spawnPos.transform.position);
            lineRenderer1.positionCount = 2;
            lineRenderer1.SetPosition(lineRenderer1.positionCount - 1, hit.point);
            lineRenderer2.enabled = true;
            lineRenderer2.positionCount = 1;
            lineRenderer2.SetPosition(0, hit.point);
            lineRenderer2.positionCount = 2;
            lineRenderer2.SetPosition(1, hit.point+reflection*2);

        }
        else
        {
           
            lineRenderer1.positionCount = 2;
            lineRenderer2.enabled = false; 
            lineRenderer1.SetPosition(lineRenderer1.positionCount - 1,pt1);
        }
    }
    
    public void SetNoOfBalls()
    {
        noOfBalls += addBall;
        addBall = 0;
    }
}



