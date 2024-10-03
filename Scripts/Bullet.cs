using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float speed;
    public int damage;
    public float destroyDistance;

    private Rigidbody2D rb;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       rb.velocity = transform.right * speed;
       startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (transform.position - startPos).sqrMagnitude;
        if (distance > destroyDistance)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")){
            Destroy(gameObject);
        }
    }
}
