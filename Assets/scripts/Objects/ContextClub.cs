using UnityEngine;

public class ContextClub : MonoBehaviour
{
    public GameObject context;

    public bool FaleContext = false;

    public void Change()
    {
        FaleContext = !FaleContext; // Nếu Nó Vô Thì Sẽ Bật
        if (FaleContext)
        {
            context.SetActive(true);
        }
        else
        {
            context.SetActive(false);
        }
    }

    
}
