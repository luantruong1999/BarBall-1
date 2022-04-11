using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarPrefab : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private RectTransform rectTransform;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        boxCollider.size = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            StartCoroutine(Move("left"));
        }

        if (Input.GetKey(KeyCode.D))
        {
            StartCoroutine(Move("right"));
        }
    }

    private float moveTime;
    private float moveDuration = 0.1f;
    private Vector2 startPosition, endPosition;

    private IEnumerator Move(string move)
    {
        switch (move)
        {
            case "left":
                moveTime = 0f;
                startPosition = transform.position;
                endPosition = new Vector2
                    (startPosition.x - 3f, transform.position.y);

                while (moveTime < moveDuration)
                {
                    moveTime += Time.deltaTime;
                    transform.position = Vector2.Lerp
                        (startPosition, endPosition, moveTime / moveDuration);
                    yield return null;
                }
                break;

            case "right":
                moveTime = 0f;
                startPosition = transform.position;
                endPosition = new Vector2
                    (startPosition.x + 3f, transform.position.y);

                while (moveTime < moveDuration)
                {
                    moveTime += Time.deltaTime;
                    transform.position = Vector2.Lerp
                        (startPosition, endPosition, moveTime / moveDuration);
                    yield return null;
                }
                break;
        }

    }
}
