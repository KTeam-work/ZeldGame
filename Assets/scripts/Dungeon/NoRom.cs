using System;
using Unity.Cinemachine;
using UnityEngine;

public class NoRom : MonoBehaviour
{
    public CinemachineConfiner2D cine;

    public PolygonCollider2D poly;
    public Transform Player;

    [SerializeField] private Vector3 Vitri;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.position += Vitri;
            cine.BoundingShape2D = poly;
            cine.InvalidateBoundingShapeCache();
        }
    }
}
