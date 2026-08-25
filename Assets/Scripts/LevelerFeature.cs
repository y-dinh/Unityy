using TMPro;
using UnityEngine;

    public class LevelerFeature : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    [SerializeField] private float levelerTolerance = 5.0f;
    [SerializeField] private TextMeshPro levelerReadingText;
    [SerializeField] private Renderer levelerOuterRenderer;

    private Color levelerDefautColor;

    void Awake()
    {
        // Referenzen automatisch auflösen, falls sie (z. B. bei menügespawnten
        // Instanzen) nicht im Prefab zugewiesen sind – sonst bliebe die Anzeige
        // fest auf "0" und die Farbe würde sich nie ändern.
        if (levelerReadingText == null)
            levelerReadingText = GetComponentInChildren<TextMeshPro>(true);

        if (levelerOuterRenderer == null)
        {
            var outer = transform.Find("OuterArea");
            if (outer != null)
                levelerOuterRenderer = outer.GetComponent<Renderer>();
        }

        if (levelerOuterRenderer != null)
            levelerDefautColor = levelerOuterRenderer.material.color;
    }

    void Update()
    {
        if (levelerReadingText == null || levelerOuterRenderer == null)
            return;

        // Winkel zwischen der Oberseite des Objekts und der Welt-Oberseite.
        // (Vorher wurde fälschlich transform.position als Richtung benutzt.)
        Vector3 objectUp = transform.up;
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
