﻿using System.Collections;

using UnityEngine;

public class BarPrefab : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private RectTransform _rectTransform;
    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _rectTransform = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        var rect = _rectTransform.rect;
        _boxCollider.size = new Vector2(rect.width, rect.height);
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

    private float _moveTime;
    private float moveDuration = 0.1f;
    private Vector2 _startPosition, _endPosition;

    private IEnumerator Move(string move)
    {
        switch (move)
        {
            case "left":
                _moveTime = 0f;
                var position = transform.position;
                _startPosition = position;
                _endPosition = new Vector2
                    (_startPosition.x - 3f, position.y);

                while (_moveTime < moveDuration)
                {
                    _moveTime += Time.deltaTime;
                    transform.position = Vector2.Lerp
                        (_startPosition, _endPosition, _moveTime / moveDuration);
                    yield return null;
                }
                break;

            case "right":
                _moveTime = 0f;
                var transform1 = transform;
                var position1 = transform1.position;
                _startPosition = position1;
                _endPosition = new Vector2
                    (_startPosition.x + 3f, position1.y);

                while (_moveTime < moveDuration)
                {
                    _moveTime += Time.deltaTime;
                    transform.position = Vector2.Lerp
                        (_startPosition, _endPosition, _moveTime / moveDuration);
                    yield return null;
                }
                break;
            case "up":
                _moveTime = 0f;
                var position3 = transform.position;
                _startPosition = position3;
                _endPosition = new Vector2
                    (_startPosition.x , position3.y + 3f);

                while (_moveTime < moveDuration)
                {
                    _moveTime += Time.deltaTime;
                    transform.position = Vector2.Lerp
                        (_startPosition, _endPosition, _moveTime / moveDuration);
                    yield return null;
                }
                break;
            case "down":
                _moveTime = 0f;
                var transform4 = transform;
                var position4 = transform4.position;
                _startPosition = position4;
                _endPosition = new Vector2
                    (_startPosition.x , position4.y - 3f);

                while (_moveTime < moveDuration)
                {
                    _moveTime += Time.deltaTime;
                    transform.position = Vector2.Lerp
                        (_startPosition, _endPosition, _moveTime / moveDuration);
                    yield return null;
                }
                break;
        }

    }
}
