using UnityEngine;
using UnityEngine.UI;
public class GUISpawner : MonoBehaviour
{
    void Start()
    {
        GameObject canvasGO = new GameObject("Canvas");

        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;

        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();
    }    
}
