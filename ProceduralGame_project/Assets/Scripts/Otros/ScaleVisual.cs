
using UnityEngine;
using UnityEngine.UI;


public class ScaleVisual : MonoBehaviour
{
    public Slider slider;
    public Text valueDisplay;
    public void UpdateScale()
    {
        Time.timeScale = slider.value;
        valueDisplay.text = slider.value.ToString();
    }
}
