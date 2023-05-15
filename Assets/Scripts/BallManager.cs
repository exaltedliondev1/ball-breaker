using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance;
    [SerializeField] private GameObject[] balls;
    [SerializeField] private int noOfBalls = 5;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private float speed = 70f;
    public int detectBall;
    public Transform Arrow;
    public bool clickEnable = true;


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

        SetUpBalls();
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 heldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Arrow.LookAt(heldPosition, new Vector3(0, 0, 1));
        }






        if (Input.GetMouseButtonUp(0) && clickEnable==true)
        {
            clickEnable = false;
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


    IEnumerator MoveBall(Vector2 moveDirection)
    {
        for (int i = 0; i < noOfBalls; i++)
        {
            Vector2 velocity = moveDirection * speed;
            Ball balli = balls[i].GetComponent<Ball>();
            if (balli != null)
            {
                balli.VelocityOnClick(velocity);
            }
            if (i == noOfBalls - 1)
            {
                spawnPos.SetActive(false);
            }
            yield return new WaitForSeconds(0.5f);
        }



        /*foreach(GameObject ball in balls)
        {
            Vector2 velocity = moveDirection * speed;
            Ball balli = ball.GetComponent<Ball>();
            if (balli != null)
            {
                balli.VelocityOnClick(velocity);
            }
            yield return new WaitForSeconds(0.5f);
        }*/

    }

    public void SetSpawnPosition(Transform BallTransform)
    {
        if(detectBall == 1)
        {
            spawnPos.transform.position = BallTransform.position;
            spawnPos.SetActive(true);
            Arrow.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if(detectBall == noOfBalls)
        {
            SetUpBalls();
            detectBall = 0;
            clickEnable = true;

        }
        
      
    }

    public void SetUpBalls()
    {
        balls = new GameObject[noOfBalls];
    }
}
