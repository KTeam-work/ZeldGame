using Unity.Cinemachine;
using UnityEngine;

public class CameraOnConfiger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var vacm = Object.FindAnyObjectByType<CinemachineConfiner2D>();
            if (vacm)
            {
                vacm.BoundingShape2D = GetComponent<PolygonCollider2D>();
                vacm.InvalidateBoundingShapeCache();
            }
        }
    }
}
