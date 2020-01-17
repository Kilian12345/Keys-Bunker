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
        if (collision.gameObject.tag == "Tile" && Input.GetKeyDown(KeyCode.Space))
        {
            GameObject tile = collision.gameObject;
            tile.tag = "TARGETED";
            SpriteRenderer tileSprite = collision.gameObject.GetComponent<SpriteRenderer>();
            tileSprite.enabled = true;

        }
    }
}
