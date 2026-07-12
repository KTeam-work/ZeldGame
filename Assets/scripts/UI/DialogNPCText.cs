
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using System.Collections;



public class DialogNPCText : MonoBehaviour
{
    // cái action hành động nhấn space

    [SerializeField]private GameObject ManagerDiaLog;
    [SerializeField]private GameObject textPrefabs;
    [SerializeField]private GameObject ButtonPrefabs;
    [SerializeField] private TextAssetValue dialogValue;

    [Header("Parent Dialog")]
    [SerializeField] private GameObject DialogHolder;
    [SerializeField] private GameObject ChoiceHolder;

    [Header("Câu chuyện")]
    [SerializeField] private Story myStory;

    [Header("Scroll")] 
    [SerializeField] private ScrollRect DialogScroll; // One(first) , 0 (Last)

    public void EnableDialog()
    {
        ManagerDiaLog.SetActive(true);
        SetStory();
        ResehView();
    }

    // Tạo cuộc trò chuyện
    public void SetStory()
    {
        if (dialogValue.Value)
        {
            ResetDialog();
            myStory = new Story(dialogValue.Value.text);// Lấy dữ liệu của hộp thoại
        }
        else
        {
            Debug.Log("Something wrong with story");
        }

    }
    
    // Làm mới cuộc hoại thoại khi mở
    public void ResehView()
    {
        while (myStory.canContinue)  // Check true || Flase
        {
            MakeNewDialog(myStory.Continue()); // myStory.Continue() Return Text
        }


        if(myStory.currentChoices.Count > 0)
        {
            MakeNewChoice();
        }
        else
        {
            ManagerDiaLog.SetActive(false);
        }
        StartCoroutine(WaitScrool());
    }

    IEnumerator WaitScrool()
    {
        yield return null;
        DialogScroll.verticalNormalizedPosition = 0f;
    }
    
    // Tạo mỗi đối tượng Dialog
    public void MakeNewDialog(string NewText)
    {
        // Những với mỗi lời thoại tạo một text ở gốc cha
        DialogText NewDialogText = Instantiate(textPrefabs,DialogHolder.transform).GetComponent<DialogText>();
        NewDialogText.SetUp(NewText);
    }

    // Xoá nội dung hộp thoại
    public void ResetDialog()
    {
        for(int i =0; i < DialogHolder.transform.childCount; i++)
        {
            Destroy(DialogHolder.transform.GetChild(i).gameObject);
        }
    }



    public void MakeNewChoice()
    {
        // Xoá hết cả lựa chọn khi mở
        for(int i =0; i < ChoiceHolder.transform.childCount; i++)
        {
            Destroy(ChoiceHolder.transform.GetChild(i).gameObject);
        }

        // Tạo lựa chọn
        for(int i =0; i < myStory.currentChoices.Count; i++)
        {
            MakeNewRespostive(myStory.currentChoices[i].text,i);
        }
    }


    // Tạo một đối tương button
    public void MakeNewRespostive(string NewText, int choice)
    {
        // Những với mỗi lựa chọn tạo một text ở gốc cha
        DialogChoice NewDialogButton = Instantiate(ButtonPrefabs,ChoiceHolder.transform).GetComponent<DialogChoice>();
        NewDialogButton.SetUp(NewText,choice);

        Button newButton = NewDialogButton.gameObject.GetComponent<Button>();
        if (newButton)
        {
            Debug.Log("Tìm thấy");
            newButton.onClick.AddListener(delegate{ChosseChoice(choice);});
        }
    }


    // Truyền vào vị trị của Mystore khi chọn một câu trả lời
    public void ChosseChoice(int index)
    {
        myStory.ChooseChoiceIndex(index); // chọn câu hỏi nào
        ResehView();
    }

}
