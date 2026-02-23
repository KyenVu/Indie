using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Khai báo biến 
    public float moveSpeed = 5f;
    private Rigidbody2D rb; //Rigigbody để điều khiển nhân vật
    private Vector2 movement; // Vecto di chuyển



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveX = 0f;
        float moveY = 0f;

        //Kiểm tra các phim di chuyển
        if (Input.GetKey(KeyCode.W)) // di chuyển lên
        {
            moveY = 1f;
        }
        if (Input.GetKey(KeyCode.S)) // di chuyển xuống
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A)) // di chuyển trái
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D)) // di chuyển phải
        {
            moveX = 1f;
        }
        // Tạo vector di chuyển
        movement = new Vector2(moveX, moveY).normalized;

        // Di chuyển player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

    }
}
