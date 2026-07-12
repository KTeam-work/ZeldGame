using UnityEngine;
using UnityEngine.Events;
public class Listener : MonoBehaviour
{
    public Signal s;
    public UnityEvent E;
    public void ARasise()
    {
       
        E.Invoke(); // Là Khoảng Thời Gian Bị Delay giống với StartCorution
    }

    // Kiểm Tra Có Va Chạm kh
    private void OnEnable()
    {
        s.OnListener(this); // Để tạm this
    }

    private void OnDisable()
    {
        s.DisListener(this);
    }
}
