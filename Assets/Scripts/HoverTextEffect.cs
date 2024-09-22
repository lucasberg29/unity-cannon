using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class HoverTextEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI textMeshPro;
    private Color originalColor;

    public Color hoverColor;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        originalColor = textMeshPro.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        textMeshPro.color = hoverColor;
    }

    // Method when pointer exits the text area
    public void OnPointerExit(PointerEventData eventData)
    {
        textMeshPro.color = originalColor;
    }
}
