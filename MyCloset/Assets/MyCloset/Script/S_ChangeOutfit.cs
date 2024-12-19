using UnityEngine;

public class S_ChangeOutfit : MonoBehaviour
{
    // Reference to the S_GlobalVars script
    private S_GlobalVars globalVars;

    // GameObjects for the garments
    public GameObject Garment1Object;
    public GameObject Garment2Object;
    public GameObject Garment3Object;
    public GameObject Garment4Object;

    void Start()
    {
        // Get the S_GlobalVars component from the parent object
        globalVars = GetComponentInParent<S_GlobalVars>();

        if (globalVars == null)
        {
            Debug.LogError("S_GlobalVars script not found on parent object!");
        }

        // Set initial garment visibility based on the global vars
        UpdateGarmentVisibility();
    }

    // Method to update the visibility based on the global variables
    void UpdateGarmentVisibility()
    {
        // Garment 1 visibility
        if (globalVars != null)
        {
            Garment1Object.SetActive(globalVars.Garment1);
            Garment2Object.SetActive(globalVars.Garment2);
            Garment3Object.SetActive(globalVars.Garment3);
            Garment4Object.SetActive(globalVars.Garment4);
        }
    }

    // Example method to toggle a specific garment's visibility
    public void ToggleGarment1(bool isVisible)
    {
        if (globalVars != null)
        {
            globalVars.Garment1 = isVisible;
            UpdateGarmentVisibility();
        }
    }

    public void ToggleGarment2(bool isVisible)
    {
        if (globalVars != null)
        {
            globalVars.Garment2 = isVisible;
            UpdateGarmentVisibility();
        }
    }

    public void ToggleGarment3(bool isVisible)
    {
        if (globalVars != null)
        {
            globalVars.Garment3 = isVisible;
            UpdateGarmentVisibility();
        }
    }

    public void ToggleGarment4(bool isVisible)
    {
        if (globalVars != null)
        {
            globalVars.Garment4 = isVisible;
            UpdateGarmentVisibility();
        }
    }
}
