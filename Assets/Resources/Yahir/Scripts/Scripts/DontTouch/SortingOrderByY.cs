using UnityEngine;

public class SortingOrderByY : MonoBehaviour
{
    private SpriteRenderer sr;
    
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        sr.sortingOrder = 1 + Mathf.RoundToInt(1000 + transform.position.y * 100);
    }

}
