using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BallManager : MonoBehaviour
{

    public static BallManager Instance;
   // [SerializeField] private GameObject[] balls;
    [SerializeField] private List<GameObject> ballList;
    [SerializeField] public int noOfBalls = 10;



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
    public LayerMask layer;
    Vector2 reflection;

    private void Awake()
    {
        Instance = this;
        
    }




    void Start()
    {

        SetUpBalls();
        SetUpScoreText(noOfBalls);
        SetLineOff();
        
    }
    
    /*===================================================== ArrowRotation ===================================*/
    public void ArrowRotation(Vector3 heldPosition)
    {


        if (clickEnable == true)
        {

            spawnPos.transform.LookAt(heldPosition, new Vector3(0, 0, 1));
            Arrow.transform.LookAt(heldPosition, new Vector3(0, 0, 1));

            GenerateLine();

        }

    }

    public float rotation;
    public void ArrowRotateOnSlider(float rotationValue)
    {
        this.rotation = rotationValue;
        spawnPos.transform.rotation = Quaternion.Euler(0, 0, rotation);
        Arrow.transform.rotation = Quaternion.Euler(0, 0, rotation);
        GenerateLine();
    }

    /*========================================== BallMovement =================================================*/
    public void BallMovement()
    {        
        if(clickEnable == true)
        {
            SetNoOfBalls();
            SetLineOff();
            clickEnable = false;
            spawnPos.SetActive(false);
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 moveDirection = (clickPosition - (Vector2)spawnPos.transform.position).normalized;
            for (int i = 0; i < noOfBalls; i++)
            {
                GameObject ball = Instantiate(ballPrefab, spawnPos.transform.position, Quaternion.identity);
                // balls[i] = ball;
                ballList.Add(ball);
            }
            StartCoroutine(MoveBall(moveDirection));
        }
    }

    public void SliderBallMovement()
    {
        if (clickEnable == true)
        {
            //SetNoOfBalls();
            SetLineOff();
            clickEnable = false;
            spawnPos.SetActive(false);
            //Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 moveDirection = spawnPos.transform.up;
            for (int i = 0; i < noOfBalls; i++)
            {
                GameObject ball = Instantiate(ballPrefab, spawnPos.transform.position, Quaternion.identity);
                // balls[i] = ball;
                ballList.Add(ball);
            }
            StartCoroutine(MoveBall(moveDirection));
        }
    }

    IEnumerator MoveBall(Vector2 moveDirection)
    {
        for (int i = 0; i < noOfBalls; i++)
        {
            Vector2 direction = moveDirection * speed;
            if (ballList[i] != null)//
            {
                Ball balli = ballList[i].GetComponent<Ball>();//
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

  /*============================================= SettingSpawner=======================================*/

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
            Board.Instance.MoveGrid(1);
            SetNoOfBalls();
            SetUpBalls();
            ballScore = noOfBalls;
            SetUpScoreText(ballScore);
            detectBall = 0;
            clickEnable = true;
            ballText.SetActive(true);
        }
    }

/*========================================================== GeneratingAimLine ==================================*/

    void GenerateLine()
    {
        // Raycasting 
        hit = Physics2D.Raycast(spawnPos.transform.position, spawnPos.transform.up,Mathf.Infinity,layer);
        Vector2 pt1 = spawnPos.transform.position + spawnPos.transform.up;
        if (hit.collider != null)
        {

            SetLineOn();
            reflection = Vector2.Reflect(spawnPos.transform.up, hit.normal);
            // Setting Line 1
            lineRenderer1.positionCount = 1;
            lineRenderer1.SetPosition(0, spawnPos.transform.position);
            lineRenderer1.positionCount = 2;
            lineRenderer1.SetPosition(lineRenderer1.positionCount - 1, hit.point);
            // Setting Line 2
            lineRenderer2.positionCount = 1;
            lineRenderer2.SetPosition(0, hit.point);
            lineRenderer2.positionCount = 2;
            lineRenderer2.SetPosition(1, hit.point+reflection*2);

        }
        else
        {   
            // Disable Line 2
            lineRenderer2.enabled = false;
            // Setting Line 1
            lineRenderer1.positionCount = 2;           
            lineRenderer1.SetPosition(lineRenderer1.positionCount - 1,pt1);
        }
    }

    /*============================================== Additional Functions ===========================*/
    public void SetLineOff()
    {
        lineRenderer1.enabled = false;
        lineRenderer2.enabled = false;
    }

    public void SetLineOn()
    {
        lineRenderer1.enabled = true;
        lineRenderer2.enabled = true;
    }
    public void SetUpBalls()
    {
        //balls = new GameObject[noOfBalls];
        ballList = new List<GameObject>();
    }
    public void SetUpScoreText(int noOfBalls)
    {
        TextMesh Text = ballText.GetComponent<TextMesh>();
        Text.text = "x" + " " + noOfBalls.ToString();
        ballScore = noOfBalls;
    }
    public void SetNoOfBalls()
    {
        noOfBalls += addBall;
        addBall = 0;
    }
}



