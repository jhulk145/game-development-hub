using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    public bool isJumping;
    public GameObject startPos;
    private float move;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(transform.position.x, jump));
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        } 
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Death collision detected");
            transform.position = new Vector2(startPos.transform.position.x, startPos.transform.position.y);
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Amazing end point reached");
            SceneManager.LoadScene("Level 2");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        } 
    }
}
