using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    [SerializeField] float degPerSecond = 10f;
    public static float skyboxRotation = 0;

    private void Update()
    {
        skyboxRotation += Time.deltaTime * degPerSecond;
        RenderSettings.skybox.SetFloat("_Rotation", skyboxRotation);
    }
}