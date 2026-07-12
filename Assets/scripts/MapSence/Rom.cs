using System.Linq;
using UnityEngine;

public class Rom : MonoBehaviour
{
    public Enemy[]  enemies;

    public Pot[] Pots;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            if(enemies != null)
            {
                for(int i = 0; i < enemies.Length; i++)
                {
                    ChangeActive(enemies[i],true);
                }
            }

            for(int i =0; i < Pots.Length; i++)
            {
                ChangeActive(Pots[i],true);
            }
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
           if(enemies != null)
            {
                for(int i = 0; i < enemies.Length; i++)
                {
                    ChangeActive(enemies[i],false);
                }
            }

            for(int i =0; i < Pots.Length; i++)
            {
                ChangeActive(Pots[i],false);
            }
        }
    }

    // Hàm Chuyển Đổi trạng thái
    public void ChangeActive(Component obj, bool active)  // obj là đối tượng chứa chức năng
    {                                                     // active là để biết trạng thái
        obj.gameObject.SetActive(active);
    }
}
