using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderWrapper : MonoBehaviour
{
    public TextMeshProUGUI Value;
    public TextMeshProUGUI Min;
    public TextMeshProUGUI Max;

    public RotorSpinner Spinner;

    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(arg0 =>
        {
            Value.text = arg0.ToString();
            Min.text = slider.minValue.ToString();
            Max.text = slider.maxValue.ToString();

            Spinner.SpeedFactor = arg0;
        });
        slider.onValueChanged.Invoke(1);
    }
}
