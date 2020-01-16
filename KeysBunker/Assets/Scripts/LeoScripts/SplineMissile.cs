using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class SplineMissile : MonoBehaviour
{
    /* THIS CLASS IS INSTANTIATED BY THE BEZIER SPLINE CLASS. IT FOLLOWS
     * A SET OF WAYPOINTS AND IS DESTROYED ON COLLISION? ALONG WITH THE SPLINE
     */

    //TWEEN VALUES
    [SerializeField] float time;
    [SerializeField] Vector3 change;
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 targetPosition;
    [SerializeField] float duration;

    [SerializeField] Sprite targetedObject;
    [ShowInInspector] Queue<GameObject> receivedNodeQueue;
    AudioSource audioSource;

    public float xCoord;
    public float yCoord;
    public float xFrequency;
    public float yFrequency;

    Vector2 prevMaxInterval = new Vector2(2,1);
    Vector2 prevMinInterval = new Vector2(-2,-1);

    Vector2 nextMaxInterval = new Vector2(1.75f, .5f);
    Vector2 nextMinInterval = new Vector2(-1.75f, -.5f);

    TrailRenderer trailRenderer;

    bool isDestroyable;
    bool isPlaying;

    float clipLength;
    float cooldownPassed;


    //max script
    SpriteRenderer mat;
    bool IsExploding = false;

    [HideInInspector] public bool hasHit = false;

    // Start is called before the first frame update
    void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        audioSource = GetComponent<AudioSource>();
        mat = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MissileMovement();
        PlaySoundCooldown();
        CheckExploding();
    }

    private void CheckExploding()
    {
        if (IsExploding)
        {
            float value = mat.material.GetFloat("_Cutoff");
            mat.material.SetFloat("_Cutoff", value - 0.1f);

            if (value <= 0)
            {
                IsExploding = false;
                //mat.material.SetFloat("_Cutoff", 1);
                Destroy(gameObject);
            }
        }
    }

    private void PlaySoundCooldown()
    {
        if (cooldownPassed >= clipLength + .5f) isPlaying = false;
        else cooldownPassed += Time.deltaTime;
    }

    void IsDestroyable()
    {
        Debug.Log("Message Received");
        isDestroyable = true;
    }

    private void MissileMovement()
    {
        change = targetPosition - startPosition;

        if (time <= duration)
        {
            time += Time.deltaTime;
            transform.position = new Vector2(TweenManager.LinearTween(time, startPosition.x, change.x, duration), 
                TweenManager.LinearTween(time, startPosition.y, change.y, duration));
        }

        if (time >= duration)
        {
            receivedNodeQueue.Dequeue();
            targetPosition = receivedNodeQueue.Peek().transform.position;
            startPosition = transform.position;
            time = 0f;
        }
    }

    void ReceiveNodeQueue(Queue<GameObject> queue)
    {
        receivedNodeQueue = queue;
        startPosition = receivedNodeQueue.Peek().transform.position;
        targetPosition = receivedNodeQueue.Peek().transform.position;
        trailRenderer.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Counter Measure")
        {
            IsExploding = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "LISTENING" && !isPlaying)
        {
            cooldownPassed = 0f;
            isPlaying = true;
            audioSource.Play();
            clipLength = audioSource.clip.length;
        }

        if (other.gameObject.tag == "Base" && isDestroyable)
        {
            IsExploding = true;
        }

        if (other.gameObject.tag == "TARGETED")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = targetedObject;
            print("FUCK! " + gameObject.name + " is being targeted");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "LISTENING" || other.gameObject.tag == "TARGETED")
        {
            audioSource.Stop();
        }
    }

    void OnDestroy()
    {
        GameObject parentObject = gameObject.transform.parent.gameObject;
        Destroy(parentObject);
        if (gameObject.transform.parent.tag == "Missile") MissileManager.currentMissiles--;
        MissileManager.currentUFOS--;
    }
}