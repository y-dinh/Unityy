using UnityEngine;

/// <summary>
/// Richtet ein Objekt (z. B. eine TextMeshPro-Anzeige) exakt parallel zur Kamera aus.
/// Dadurch bleibt Text aus jedem Blickwinkel lesbar – nicht gespiegelt und nicht
/// gekippt, auch nicht von unten. Ersetzt das paket-eigene BillboardAlignment,
/// das mit Welt-Oben arbeitete und den Text dadurch spiegeln konnte.
/// </summary>
public class FaceCamera : MonoBehaviour
{
    private Transform cam;

    public void SetCamera(Transform cameraTransform) => cam = cameraTransform;

    private void LateUpdate()
    {
        if (cam == null)
        {
            if (Camera.main == null) return;
            cam = Camera.main.transform;
        }

        // Gleiche Ausrichtung wie die Kamera => Textebene immer parallel zum Bild,
        // damit lesbar und niemals gespiegelt.
        transform.rotation = cam.rotation;
    }
}
