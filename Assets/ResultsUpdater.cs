using TMPro;
using UnityEngine;

public class ResultsUpdater : MonoBehaviour
{
    public FloatVariable AngularV;
    public FloatVariable MechV;
    public FloatVariable EffV;
    public FloatVariable EnergyV;

    public TextMeshProUGUI Angular;
    public TextMeshProUGUI Mech;
    public TextMeshProUGUI Eff;
    public TextMeshProUGUI Energy;

    private void Update()
    {
        Angular.text = AngularV.Value.ToString();
        Mech.text = MechV.Value.ToString();
        Eff.text = EffV.Value.ToString();
        Energy.text = EnergyV.Value.ToString();
    }
}
