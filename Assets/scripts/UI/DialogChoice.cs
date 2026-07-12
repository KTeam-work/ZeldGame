using UnityEngine;
using TMPro;

public class DialogChoice : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private int _Choice;

    public void SetUp(string NewText, int choice)
    {
        _text.text = NewText;
        _Choice = choice;
    }
}
