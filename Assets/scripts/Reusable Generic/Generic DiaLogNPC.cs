using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GenericDiaLogNPC : InteracTabel
{
    [SerializeField] private PlayerInput _playerI;
    private InputAction Eaction;
    [SerializeField] private TextAssetValue DialogValue;
    // Save Hộp thoại
    [SerializeField] private TextAsset myAsset;
    // Gọi để mở hộp thoại
    [SerializeField] private Signal brachingDialog;

    void Start()
    {
        Eaction = _playerI.actions["DialogNPC"];
    }

    private void Update()
    {
        if (PlayerIs)
        {
            if (Eaction.triggered)
            {
                DialogValue.Value = myAsset; // để biết hiển thị hộp thoại nào
                brachingDialog.Rasie();
            }
        }
    }

}
