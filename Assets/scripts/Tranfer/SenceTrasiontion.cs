using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class SenceTrasiontion : MainSencen
{
   public string Name;
   public PlayerPosition player;
   public Vector2 Postion;

   public ScrenFade fade;
   public GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {        
            
            StartCoroutine(ToiDan());    
           
        }
    }


    public IEnumerator ToiDan()
    {


        yield return StartCoroutine(fade.FadeOut());
        
        _gameManager.SetSence(Postion);// Gọi để lưu dữ liệu trước khi chuyển scene
         
        Debug.Log($"Loading: {Name}");
        SceneManager.LoadScene(Name);
        
       
        
    }
}
