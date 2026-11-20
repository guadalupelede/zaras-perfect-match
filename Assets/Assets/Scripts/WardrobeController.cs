using UnityEngine;

public class WardrobeController : MonoBehaviour
{
    public enum ClothingCategory
    {
        Top,
        Bottom,
        Shoes
    }

    [Header("Prendas ya calibradas en CharacterModel")]
    public GameObject[] topItems;
    public GameObject[] bottomItems;
    public GameObject[] shoesItems;

    public void SelectItem(ClothingCategory category, GameObject targetItem)
    {
        switch (category)
        {
            case ClothingCategory.Top:
                ToggleGroup(topItems, targetItem);
                break;

            case ClothingCategory.Bottom:
                ToggleGroup(bottomItems, targetItem);
                break;

            case ClothingCategory.Shoes:
                ToggleGroup(shoesItems, targetItem);
                break;
        }
    }

    private void ToggleGroup(GameObject[] group, GameObject targetItem)
    {
        if (group == null) return;

        for (int i = 0; i < group.Length; i++)
        {
            if (group[i] != null)
            {
                group[i].SetActive(group[i] == targetItem);
            }
        }
    }
}