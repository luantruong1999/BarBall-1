using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPrefab : MonoBehaviour
{
    private RectTransform rectTransform;
    private CircleCollider2D circleCollider;
    private new Rigidbody2D rigidbody;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        circleCollider = GetComponent<CircleCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        circleCollider.radius = rectTransform.rect.width / 2;
        rigidbody.AddForce(new Vector2(100, 100) *speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            rigidbody.AddForce(new Vector2(100, 100));
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            rigidbody.AddForce(new Vector2(- 100,- 100));
        }

        
    }

}
