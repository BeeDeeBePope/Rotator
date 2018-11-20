using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldWrapper : MonoBehaviour
{
    public FloatVariable Variable;

    private InputField input;

    private string currentVal;

    private void Awake()
    {
        input = GetComponent<InputField>();

        input.onValueChanged.AddListener(arg0 =>
        {
            float val = 0;
            if (float.TryParse(arg0, out val))
            {
                Variable.Value = val;
                currentVal = arg0;
            }
            else
            {
                input.text = currentVal;
            }
            
        });
        input.onValueChanged.Invoke("10");
    }
}
