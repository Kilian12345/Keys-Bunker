﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float speed;
    public Sprite targetTileSprite;
    AudioSource[] activeAudioSources;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal2") * speed, Input.GetAxis("Vertical2") * speed, 0));        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            activeAudioSources = collision.gameObject.GetComponents<AudioSource>();
            foreach (AudioSource audio in activeAudioSources)
            {
                audio.Play();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject tile = collision.gameObject;
                tile.tag = "TARGETED";
                SpriteRenderer tileSprite = collision.gameObject.GetComponent<SpriteRenderer>();
                tileSprite.enabled = true;
            }
        }
    }
}