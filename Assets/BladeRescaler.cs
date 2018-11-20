using UnityEngine;

public class BladeRescaler : MonoBehaviour
{
    public GameObject Blade1;
    public GameObject Blade2;
    public GameObject Blade3;

    private RotorSpinner spinner;

    private void Start()
    {
        spinner = GetComponent<RotorSpinner>();
    }

    private void Update()
    {
        float length = spinner.TurbineBladeLength;
        float scaleMultiplier = (length - 25.2f) / (58 - 25.2f) + 1;
        Vector3 scale = Blade1.transform.localScale;
        scale.x = scaleMultiplier;
        Blade1.transform.localScale = scale;
        Blade2.transform.localScale = scale;
        Blade3.transform.localScale = scale;
    }
}
