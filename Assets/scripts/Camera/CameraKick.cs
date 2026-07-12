using UnityEngine;

public class CameraKick : MonoBehaviour
{
    [SerializeField] private Signal CameKick;

    public void ScreenKick()
    {
        if(CameKick)
        {
            CameKick.Rasie();
        }
    }
}
