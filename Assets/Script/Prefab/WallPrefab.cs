using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPrefab : MonoBehaviour
{
    private RectTransform rectTransform;
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        boxCollider.size = new Vector2(rectTransform.rect.width, rectTransform.rect.height);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
