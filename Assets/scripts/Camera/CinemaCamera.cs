using System.Collections;
using UnityEngine;

public class CinemaCamera : MonoBehaviour
{
    

    private Animator ani;

    public void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void ScreenKickCamero()
    {
        ani.SetBool("Kick",true);
        StartCoroutine(WaiScreenKick());  // Thay vì tắt nhanh mà chờ hết 1 famre rùi tắt sẽ nhìn mượt hơn
    }
    
    IEnumerator WaiScreenKick()
    {
        yield return null;
        ani.SetBool("Kick",false);
    }


}
