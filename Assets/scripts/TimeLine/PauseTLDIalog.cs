using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;


public class PauseTLDIalog : MonoBehaviour
{
    [Header("Playable")]
    public PlayableDirector direc;
    
   
    
    [Header("Input")]
    [SerializeField] private PlayerInput PlayerIP;
    [SerializeField] private InputAction Space;
    private bool ActiveDialog = false;
    void Start() 
    {
        PlayerIP = GetComponent<PlayerInput>();
        Space = PlayerIP.actions["Attack"];
    }

    // Update is called once per frame
    void Update()
    {
        if (Space.triggered && ActiveDialog)
        {
            RemuseTimeLine();
        }
    }


    // Hàm để singal để nó bật thì tạm dừng
    public void PauseTimeLine()
    {
        direc.Pause();  // Gọi Tạm Dừng
        ActiveDialog = true;
        
    }


    // Nếu Bấm Space thì gọi hàm này
    public void RemuseTimeLine()
    {
        direc.Play(); // gọi chạy lại
        ActiveDialog = false;
       
    }
}
