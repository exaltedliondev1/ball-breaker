using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance;
    [SerializeField] private GameObject[] balls;
    [SerializeField] private int noOfBalls = 5;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float speed = 10f;
    [SerializeField] private int counter = 0;
                    
    
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        balls = new GameObject[noOfBalls];
       
    }

    
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 moveDirection = (clickPosition - transform.position).normalized;
            for (int i = 0; i < noOfBalls; i++)
            {
                GameObject ball = Instantiate(ballPrefab, spawnPos.position, Quaternion.identity);
                Debug.Log(spawnPos.position);
                balls[i] = ball;
            }
            StartCoroutine(MoveBall(moveDirection));
        }
    }


    IEnumerator MoveBall(Vector2 moveDirection)
    {
        
        foreach(GameObject ball in balls)
        {
            Vector2 velocity = moveDirection * speed;
            Ball balli = ball.GetComponent<Ball>();
            if (balli != null)
            {
                balli.VelocityOnClick(velocity);
            }
            yield return new WaitForSeconds(0.5f);



        }

    }

    public void SetSpawnPosition(Transform position)
    {
        if(counter == 1)
        {

        }
      
    }
}
