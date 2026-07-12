using UnityEngine;

public class GenericDamge : MonoBehaviour
{
    public float damageAmount; // Lượng sát thương
    [SerializeField] private string otherTag; // Tag đối tượng nhận sát thưong

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(otherTag)) // Kiểm tra nếu đối tượng có tag phù hợp
        {
            GenericHealth otherHealth = other.GetComponent<GenericHealth>();
            if (otherHealth)
            {
               
                otherHealth.TakeDamage(damageAmount); // Gọi phương thức nhận sát thương
            }
        }
    }
}
