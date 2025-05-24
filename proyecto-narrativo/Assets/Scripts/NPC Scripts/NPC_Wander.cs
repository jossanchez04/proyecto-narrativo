using UnityEngine;
using System.Collections;

public class NPC_Wander : MonoBehaviour
{
    [Header("NPC Wander Area")]
    public float wanderWidth = 5f;
    public float wanderHeight = 5f;
    public Vector2 startingPosition;

    public float pauseDuration = 1f;
    public float speed = 2f;
    public Vector2 target;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isPaused = false;
    private bool movingHorizontally = true;
    private bool xDone = false;
    private bool yDone = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        StartCoroutine(PauseAndPickNewDestination());
    }

    private void Update()
    {
        if (isPaused)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        MoveOneDirection();

        Vector2 currentPos = transform.position;
        if (!xDone && Mathf.Abs(target.x - currentPos.x) < 1f)
        {
            rb.linearVelocity = Vector2.zero;
            xDone = true;
            movingHorizontally = false;
        }
        if (!yDone && Mathf.Abs(target.y - currentPos.y) < 1f)
        {
            rb.linearVelocity = Vector2.zero;
            yDone = true;
        }

        if (xDone && yDone)
        {
            StartCoroutine(PauseAndPickNewDestination());
        }
    }

    private void MoveOneDirection()
    {
        Vector2 currentPos = transform.position;
        Vector2 direction = Vector2.zero;

        if (!xDone && movingHorizontally)
        {
            direction = (target.x > currentPos.x) ? Vector2.right : Vector2.left;
            anim.Play(target.x > currentPos.x ? "walkRight" : "walkLeft");
        }
        else if (!yDone)
        {
            direction = (target.y > currentPos.y) ? Vector2.up : Vector2.down;
            anim.Play(target.y > currentPos.y ? "walkUp" : "walkDown");
        }

        rb.linearVelocity = direction * speed;
    }

    IEnumerator PauseAndPickNewDestination()
    {
        isPaused = true;
        rb.linearVelocity = Vector2.zero;
        anim.Play("idle");
        yield return new WaitForSeconds(pauseDuration);

        target = GetRandomTarget();
        xDone = false;
        yDone = false;
        movingHorizontally = true;
        isPaused = false;
    }

    private Vector2 GetRandomTarget()
    {
        float halfWidth = wanderWidth / 2;
        float halfHeight = wanderHeight / 2;
        int edge = Random.Range(0, 4);

        return edge switch
        {
            0 => new Vector2(startingPosition.x - halfWidth, Random.Range(startingPosition.y - halfHeight, startingPosition.y + halfHeight)),
            1 => new Vector2(startingPosition.x + halfWidth, Random.Range(startingPosition.y - halfHeight, startingPosition.y + halfHeight)),
            2 => new Vector2(Random.Range(startingPosition.x - halfWidth, startingPosition.x + halfWidth), startingPosition.y - halfHeight),
            _ => new Vector2(Random.Range(startingPosition.x - halfWidth, startingPosition.x + halfWidth), startingPosition.y + halfHeight),
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(PauseAndPickNewDestination());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(startingPosition, new Vector3(wanderWidth, wanderHeight, 0));

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, target);
        Gizmos.DrawSphere(target, 0.1f);
    }
}
