using UnityEngine;
using TMPro;

public class DialogText : MonoBehaviour
{
   [SerializeField] private TMP_Text _text;

    public void SetUp(string Newtext)
    {
        _text.text = Newtext;
    }
}
