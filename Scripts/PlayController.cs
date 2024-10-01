using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public float speed = 5.0f;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x > 0)
        {
            transform.eulerAngles = new Vector3(x: 0f, y: 0f, z: 0f);
            _animator.SetBool(name: "run", value: true);
        }

        if (x < 0)
        {
            transform.eulerAngles = new Vector3(x: 0f, y: 180f, z: 0f);
            _animator.SetBool(name: "run", value: true);
        }

        if (y < 0)
        {
            _animator.SetBool(name: "run", value: true);
        }

        if (y > 0)
        {
            _animator.SetBool(name: "run", value: true);
        }

        if ((x < 0.001f && x > -0.001f) && (y < 0.001f && y > -0.001f))
        {
            _animator.SetBool(name: "run", value: false);
        }

        Vector2 position = transform.position;
        position.x += x * speed * Time.deltaTime;
        position.y += y * speed * Time.deltaTime;
        transform.position = position;
    }
}
