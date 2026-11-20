using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClothingButton : MonoBehaviour
{
    public WardrobeController wardrobeController;
    public WardrobeController.ClothingCategory category;
    public GameObject targetClothingObject;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClothingButtonClicked);
    }

    private void OnDestroy()
    {
        if (button != null)
        {
            button.onClick.RemoveListener(OnClothingButtonClicked);
        }
    }

    private void OnClothingButtonClicked()
    {
        if (wardrobeController == null)
        {
            Debug.LogWarning("Falta asignar WardrobeController en " + gameObject.name);
            return;
        }

        wardrobeController.SelectItem(category, targetClothingObject);
    }
}