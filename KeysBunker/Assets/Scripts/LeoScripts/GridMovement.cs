using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float speed;
    public float testSpeed;
    public Sprite targetTileSprite;

    Rigidbody2D rb;
    Vector2 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(dir * testSpeed);

        dir.x = Input.GetAxis("Horizontal2");
        dir.y = Input.GetAxis("Vertical2");
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal2") * speed, Input.GetAxis("Vertical2") * speed, 0));        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile" || collision.gameObject.tag == "LISTENING")
        {
            GameObject tile = collision.gameObject;

            if(collision.gameObject.tag != "TARGETED") tile.tag = "LISTENING";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                tile.tag = "TARGETED";
                SpriteRenderer tileSprite = collision.gameObject.GetComponent<SpriteRenderer>();
                tileSprite.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            collision.gameObject.tag = "TARGETED";
            SpriteRenderer tileSprite = collision.gameObject.GetComponent<SpriteRenderer>();
            tileSprite.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TARGETED")
        {
            GameObject tile = collision.gameObject;
            tile.tag = "Tile";
        }

        if (collision.gameObject.tag == "LISTENING")
        {
            GameObject tile = collision.gameObject;
            tile.tag = "Tile";
        }
    }
}
