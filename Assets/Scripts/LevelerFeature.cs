using TMPro;
using UnityEngine;

    public class LevelerFeature : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    [SerializeField] private float levelerTolerance = 5.0f;
    [SerializeField] private TextMeshPro levelerReadingText;
    [SerializeField] private Renderer levelerOuterRenderer;

    private Color levelerDefautColor;

    void Awake() => levelerDefautColor = levelerOuterRenderer.material.color;

    void Update()
    {
        Vector3 objectUp = transform.position;
        Vector3 worldUp = Vector3.up;

        int angle = Mathf.RoundToInt(Vector3.Angle(objectUp, worldUp));

        Vector3 crossProduct = Vector3.Cross(worldUp, objectUp);
        if (crossProduct.z > 0) angle = -angle;

        levelerReadingText.text = $"{angle:F0}°";
        levelerOuterRenderer.material.color = 
            angle <= levelerTolerance &&
            angle >= (levelerTolerance* -1)
            ? Color.green
            : levelerDefautColor ;

    }
}
