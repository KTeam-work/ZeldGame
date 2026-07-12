using UnityEngine;
using UnityEngine.UI;
public class MagicManager : MonoBehaviour
{
    public Slider _slider;
    public Invetory PlayerInventory;
    void Start()
    {
        _slider.maxValue = PlayerInventory.Maxslider;  // Cập thang điểm có thể bắn
        _slider.value = PlayerInventory.SliderPoint.Point;
       
    }

    //  Tăng Magic Khi nhặt được bình thuốc
    public void AddMagic()
    {
        _slider.value = PlayerInventory.SliderPoint.Point;
        if(_slider.value > PlayerInventory.Maxslider)
        {
            _slider.value = PlayerInventory.Maxslider;  
            PlayerInventory.SliderPoint.Point = PlayerInventory.Maxslider;
        }
    }


    public void DesMagic()
    {
        _slider.value = PlayerInventory.SliderPoint.Point;
        if(_slider.value < 0)
        {
            _slider.value = 0;  
            PlayerInventory.SliderPoint.Point = 0;
        }
    }
   
}
