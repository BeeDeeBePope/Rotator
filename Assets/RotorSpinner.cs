using UnityEngine;

public class RotorSpinner : MonoBehaviour
{
    public GameObject Rotor;

    [Range(0, 13.8f)]
    public float WindVelocity;
    [Range(24, 58)]
    public float TurbineBladeLength;
    [Range(58, 90)]
    public float BladeApexSpeed;
    public int SimulationTime;

    public float SpeedFactor = 1;

    public float TurbineAngularVelocity = 1.5f;
    public float TurbineCoefficientCp;
    public float TurbineSpeedCoefficientLambda;
    public float ProducedEnergy;
    public float TurbineEfficiency;

    public float WindTurbineSurface;

    public float WindCurrentPower;

    public float TurbineMechanicalPower;

    public float ElectricalPower;

    private float timer;
    private const float AirDensity = 1.225f;

    public float Lolxd;

    private void Lol()
    {
        WindTurbineSurface = Mathf.PI * TurbineBladeLength * TurbineBladeLength;
        WindCurrentPower = 1 / 2f * AirDensity * WindTurbineSurface * (WindVelocity * WindVelocity * WindVelocity);
        BladeApexSpeed = TurbineAngularVelocity / TurbineBladeLength;
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
        Rotor.transform.RotateAround(Rotor.transform.position, Rotor.transform.up, -TurbineAngularVelocity * Mathf.Rad2Deg * Time.deltaTime / 1.0f);
        //Rotor.transform.localRotation = Quaternion.SlerpUnclamped(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, -180, 0), timer);
        timer += Time.deltaTime * SpeedFactor;
        Lol();
        ProducedEnergy += ElectricalPower * Time.deltaTime;
        Lolxd = ElectricalPower * 3600 * 24 * 356;
    }



}
