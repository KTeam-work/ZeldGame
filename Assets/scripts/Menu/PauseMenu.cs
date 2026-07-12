using System.Security.Principal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [Header("Variable for PauseMenu")]
    bool isPause;
    public GameObject CanvaPause;
    private PlayerInput PlayerIn;
    private InputAction EscButton;
    
    [Header("variable for Inventory")]
    [SerializeField] private GameObject InventoryPause; // Để hiện inventory khi pause
    [SerializeField] private bool isInventoryOpen; // Biến để kiểm tra trạng thái của inventory
    
    [Header("Menu")]
    public string NameSence;
    void Start()
    {
        PlayerIn = GetComponent<PlayerInput>();
        isPause = false;
        isInventoryOpen = false;
        CanvaPause.SetActive(false);
        InventoryPause.SetActive(false);
        EscButton = PlayerIn.actions["Pause"];
    }


    void Update()
    {
        if (EscButton.triggered)
        {
            ChangeMenu();
        }
    }


    public void ChangeMenu()
    {
        isPause = !isPause; // ngược lại với hiện tại của nó
        if (isPause)
        {
            CanvaPause.SetActive(true);
            Time.timeScale =0f; // dừng lại trò chơi
        }
        else
        {
            CanvaPause.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    // Function to open Mainmenu
    public void ReutrnMenu()
    {
        SceneManager.LoadScene(NameSence);
        Time.timeScale = 1f;
    }

    public void OpenInventory()
    {
        // kiểm tra có đang bật không
        isInventoryOpen = !isInventoryOpen; // ngược lại với hiện tại của nó
        if (isInventoryOpen)
        {
            CanvaPause.SetActive(false); // ẩn menu pause đi
            InventoryPause.SetActive(true);
            Time.timeScale = 0f; // dừng lại trò chơi
        }
        else
        {
            InventoryPause.SetActive(false);// ẩn inventory đi
            CanvaPause.SetActive(true); // hiện menu pause lên
            Time.timeScale = 0f; // dừng lại trò chơi
        }
    }




}
