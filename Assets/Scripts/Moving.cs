using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Snake : MonoBehaviour
{

    //direction
    public Vector2Int direction = Vector2Int.right;// (1,0)
    private Vector2Int input;

    //reference
    public GameObject fruit;

    //grow
    public int initialSize = 0;
    private readonly List<Transform> segments = new List<Transform>();// 1 cái list kiểu transform
    public Transform segmentPrefab;

    //moving
    private float nextUpdate;//thời gian của lần move tiếp theo
    public float speed = 2f;
    //public float speedMultiplier = 1f;
    

    private void Start()
    {
        ResetState();
        
    }

    private void Update()
    {
        // Only allow turning up or down while moving in the x-axis
        if (direction.x != 0f)//moving in the x-axis
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                input = Vector2Int.up;
            } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
                input = Vector2Int.down;
            }
        }
        // Only allow turning left or right while moving in the y-axis
        else if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
                input = Vector2Int.right;
            } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                input = Vector2Int.left;
            }
        }
    }

    private void FixedUpdate()
    {   
        if(this.GetComponent<Crash>().die==false && fruit.GetComponent<FruitTrigger>().fruitOut==false){//chỉ đc move khi chưa chết và chưa thắng
        // Wait until the next update before proceeding
        if (Time.time < nextUpdate) {
            return;
        }

        // Set the new direction based on the input
        if (input != Vector2Int.zero) {
            direction = input;
        }

        // Set each segment's position to be the same as the one it follows. We
        // must do this in reverse order so the position is set to the previous
        // position, otherwise they will all be stacked on top of each other.
        for (int i = segments.Count - 1; i > 0; i--) {
            segments[i].position = segments[i - 1].position;
            FindObjectOfType<FruitTrigger>().snakeGrow=false;
        }


        // Move the snake in the direction it is facing
        float x = transform.position.x + direction.x*0.5f;//cơ chế đi là lấy vector position+ vector hướng 
        float y = transform.position.y + direction.y*0.5f;
        transform.position = new Vector2(x, y);

        // Set the next update time based on the speed
        nextUpdate = Time.time + (1f / speed);// thời gian thực của game (sec)+ thời gian giữa 2 lần move
        RotateHead();
        }
    }

    public void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segment.rotation = segments[segments.Count - 1].rotation; // Set the rotation of the new segment
        segments.Add(segment);
    }

    void RotateHead() {
        if (direction == Vector2Int.up) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if (direction == Vector2Int.down) {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        } else if (direction == Vector2Int.left) {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        } else if (direction == Vector2Int.right) {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        for (int i = 1; i < segments.Count; i++) {
            segments[i].rotation = segments[i - 1].rotation;
        }
    }
    public void ResetState()
    {
        direction = Vector2Int.right;
        transform.position = new Vector3(0,0,0);

        // Start at 1 to skip destroying the head
        for (int i = 1; i < segments.Count; i++) {
            Destroy(segments[i].gameObject);
        }

        // Clear the list but add back this as the head
        segments.Clear();
        segments.Add(transform);

        // -1 since the head is already in the list
        for (int i = 0; i < initialSize - 1; i++) {
            Grow();
        }
    }

    // public bool Occupies(int x, int y)
    // {
    //     foreach (Transform segment in segments)
    //     {
    //         if (Mathf.RoundToInt(segment.position.x) == x &&
    //             Mathf.RoundToInt(segment.position.y) == y) {
    //             return true;
    //         }
    //     }

    //     return false;
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="fruit")
        {
            Grow();
        }
    }
}