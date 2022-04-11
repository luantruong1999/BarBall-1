

using System;
using System.Collections;
using UnityEngine;

using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float timeToMove;
    [SerializeField] private bool isMoving;
    private float curHp;
    [SerializeField] private float maxHp;
    [SerializeField] private float distance;
    [Header("UI")] [SerializeField] private Image heathBarFill;
    
    
    private RectTransform _rectTransform;
    private BoxCollider2D _boxCollider;
    
    private float _moveTime;
    private float moveDuration = 0.1f;
    private Vector2 _startPosition, _endPosition;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
       
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        curHp = maxHp;
        var rect = _rectTransform.rect;
        _boxCollider.size = new Vector2(rect.width, rect.height);
        StartCoroutine("MoveDown");
    }

    IEnumerator MoveDown()
    {
        while (isMoving)
        {
            yield return new WaitForSeconds(timeToMove);
            var position = _rectTransform.position;
            StartCoroutine(Move("down"));
        }
    }

    //Nen dua no sang class khac
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            TakenDamege(1);
        }
    }

    public void TakenDamege(int damegeTaken)
    {
        curHp -= damegeTaken;
        if (curHp <= 0)
        {
            //?
            Destroy(gameObject);
        }

        UpdateHealthBar();
    }

    void UpdateHealthBar() => heathBarFill.fillAmount = (float) curHp / (float) maxHp;
    
    private IEnumerator Move(string move)
    {
        switch (move)
        {
            case "left":
                _moveTime = 0f;
                var position = transform.position;
                _startPosition = position;
                _endPosition = new Vector2
                    (_startPosition.x - distance, position.y);

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
                    (_startPosition.x + distance, position1.y);

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
                    (_startPosition.x , position3.y + distance);

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
                    (_startPosition.x , position4.y - distance);

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
