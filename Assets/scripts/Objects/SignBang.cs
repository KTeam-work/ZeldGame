using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignBang : InteracTabel
{
   

   
    // Có Đối Tượng Hộp Thoai
    public GameObject DialogBox;
    public TMP_Text PlaceText; // Phần Chữ Text
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && PlayerIs)
        {
            // Kiểm Tra Hộp Thoại Có Hoạt Động Không
            if (DialogBox.activeInHierarchy)
            {
                DialogBox.SetActive(false);
            }
            else
            {
                DialogBox.SetActive(true);
                PlaceText.text = Name;
            }
        }
    }

   

    public override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other); // Gọi Hàm Cha
        if (other.CompareTag("Player") && !other.isTrigger )
        {
            DialogBox.SetActive(false);
        }
    }
}
