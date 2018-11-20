using UnityEngine;

public class RotorSpinner : MonoBehaviour
{
    public GameObject Rotor;

    [Range(0, 13.8f)]
    public float WindVelocity;
    [Range(24, 58)]
    public float TurbineBladeLength;
    [Range(0.001f, 0.5f)]
    public float BladeApexSpeed;
    public int SimulationTime;

    public float TurbineAngularVelocity = 1.5f;
    public float TurbineCoefficientCp;
    public float TurbineSpeedCoefficientLambda;
    public float ProducedEnergy;
    public float TurbineEfficiency;

    public float WindTurbineSurface;

    public float WindCurrentPower;

    public float TurbineMechanicalPower;

    public float ElectricalPower;

    private const float AirDensity = 1.225f;

    public float EnergyAfterSimulation;

    [Header("Variables")]
    public FloatVariable WindVel;
    public FloatVariable BladeLen;
    public FloatVariable SimTime;
    public FloatVariable AngularVel;
    public FloatVariable MechPow;
    public FloatVariable ProdE;
    public FloatVariable TurbEff;

    private void Start()
    {
        
    }

    private void Lol()
    {
        BladeApexSpeed = WindVelocity / 13.8f * 0.12228f;

        WindTurbineSurface = Mathf.PI * TurbineBladeLength * TurbineBladeLength;
        WindCurrentPower = 1 / 2f * AirDensity * WindTurbineSurface * (WindVelocity * WindVelocity * WindVelocity);
        TurbineAngularVelocity = BladeApexSpeed * TurbineBladeLength;
        TurbineSpeedCoefficientLambda = BladeApexSpeed / WindVelocity;
        TurbineCoefficientCp = 0.02021f - 0.1112f * TurbineSpeedCoefficientLambda +
                               0.1056f * TurbineSpeedCoefficientLambda * TurbineSpeedCoefficientLambda -
                               0.01574f * TurbineSpeedCoefficientLambda * TurbineSpeedCoefficientLambda *
                               TurbineSpeedCoefficientLambda + 0.0004765f * TurbineSpeedCoefficientLambda *
                               TurbineSpeedCoefficientLambda * TurbineSpeedCoefficientLambda *
                               TurbineSpeedCoefficientLambda;
        TurbineMechanicalPower = WindCurrentPower * TurbineCoefficientCp;
        TurbineEfficiency = (2 * TurbineMechanicalPower) / (AirDensity * WindTurbineSurface *
                            (WindVelocity * WindVelocity * WindVelocity));
        ElectricalPower = 1 / 2f * AirDensity * WindTurbineSurface * (WindVelocity * WindVelocity * WindVelocity) * TurbineEfficiency;
    }


    private void Update()
    {
        Lol();
        Rotor.transform.RotateAround(Rotor.transform.position, Rotor.transform.up, -TurbineAngularVelocity * Mathf.Rad2Deg * Time.deltaTime / 1.0f);
        Rotor.transform.localPosition = Vector3.zero;
        ProducedEnergy += ElectricalPower * Time.deltaTime;
        EnergyAfterSimulation = ElectricalPower * SimulationTime * 24;

        WindVelocity = WindVel.Value;
        TurbineBladeLength = BladeLen.Value;
        SimulationTime = int.Parse(SimTime.Value.ToString());
        AngularVel.Value = TurbineAngularVelocity;
        MechPow.Value = TurbineMechanicalPower / 1000;
        ProdE.Value = EnergyAfterSimulation / 1000000;
        TurbEff.Value = TurbineEfficiency;
    }
}
