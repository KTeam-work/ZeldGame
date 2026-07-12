using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    private SpriteRenderer spr;
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        spr.sortingOrder = -(int)(transform.position.y * 100);  // để quyết
    }

    
}
