using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BallManager : MonoBehaviour
{

    public static BallManager Instance;
    [SerializeField] private GameObject[] balls;
    [SerializeField] public int noOfBalls = 5;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] public GameObject spawnPos;
    [SerializeField] private float speed = 70f;
    public float delay = 0.4f;
    public int detectBall;
    public Transform Arrow;
    public bool clickEnable = true;
    public GameObject ballText;
    public int ballScore;
    //public List<Transform> trajectoryDots;
    public int numberOfDots;
   // public GameObject dotPrefab;
    public LineRenderer lineRenderer1;
    public LineRenderer lineRenderer2;
    private Ray2D ray;
    private RaycastHit2D hit;

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
        GenerateLine();
    }






    void BallMovement()
    {
        if (Input.GetMouseButtonUp(0) && clickEnable == true)
        {
            lineRenderer1.enabled = false;
            lineRenderer2.enabled = false;

            clickEnable = false;
            spawnPos.SetActive(false);
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 moveDirection = (clickPosition - spawnPos.transform.position).normalized;
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
        if (Input.GetMouseButton(0))
        {
            Vector3 heldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPos.transform.LookAt(heldPosition, new Vector3(0, 0, 1));
            Arrow.transform.LookAt(heldPosition, new Vector3(0, 0, 1));
            lineRenderer1.enabled = true;
            lineRenderer2.enabled = true;
           
        }
    }

    IEnumerator MoveBall(Vector2 moveDirection)
    {
        for (int i = 0; i < noOfBalls; i++)
        {
            Vector2 velocity = moveDirection * speed;
            if (balls[i] != null)
            {
                Ball balli = balls[i].GetComponent<Ball>();
                if (balli != null)
                {
                    balli.VelocityOnClick(velocity);
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
            //Destroy(BallObject);
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
        lineRenderer1.positionCount = 1;
        lineRenderer1.SetPosition(0, spawnPos.transform.position);
        float length = 50f;

       
            hit = Physics2D.Raycast(spawnPos.transform.position, spawnPos.transform.up,length);
            if (hit.collider != null)
            {
                lineRenderer1.positionCount = 2;
                lineRenderer1.SetPosition(lineRenderer1.positionCount - 1, hit.point);
                ray = new Ray2D(hit.point, Vector2.Reflect(ray.direction, hit.normal));

                lineRenderer2.positionCount = 1;
                lineRenderer2.SetPosition(0, hit.point);
                lineRenderer2.positionCount = 2;
                lineRenderer2.SetPosition(1,ray.direction);
            }
            else
            {
                lineRenderer1.positionCount += 1;
                lineRenderer1.SetPosition(lineRenderer1.positionCount - 1, spawnPos.transform.position + spawnPos.transform.up * 3);
            }
        
       
    }
    

     


}



