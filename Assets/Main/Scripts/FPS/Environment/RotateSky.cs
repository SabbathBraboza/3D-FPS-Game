using UnityEngine;

public class RotateSky : MonoBehaviour
{

    [SerializeField] private float RotationSpeed = 2f;

    private void Start() => RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotationSpeed);

}
