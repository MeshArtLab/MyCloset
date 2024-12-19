using UnityEngine;

public class S_UpdateGlobalVars : MonoBehaviour
{
    // The name of the variable in S_GlobalVars to update
    [Tooltip("Name of the variable in S_GlobalVars to update (e.g., Garment1)")]
    public string VariableName;

    // Local value to sync with the global variable
    public bool LocalValue; // Initialize to false by default

    // Reference to S_GlobalVars
    private S_GlobalVars globalVars;

    public void SetStart()
    {
        // Get the S_GlobalVars component from the parent object
        globalVars = transform.parent.GetComponent<S_GlobalVars>();

        if (globalVars == null)
        {
            Debug.LogError("S_GlobalVars script not found on parent object!");
        }

        // Ensure LocalValue is false on start (it's already set in the declaration, but this is for safety)
        LocalValue = false;
    }

    // Method to update the global variable
    public void SetGarment(bool value)
    {
        LocalValue = value; // Update the local value

        // Ensure that the globalVars reference is valid and the VariableName is provided
        if (globalVars == null || string.IsNullOrEmpty(VariableName))
        {
            Debug.LogError("Cannot update global variable: Invalid reference or VariableName.");
            return;
        }

        // Use reflection to dynamically update the global variable
        var field = globalVars.GetType().GetField(VariableName);

        if (field != null && field.FieldType == typeof(bool))
        {
            field.SetValue(globalVars, LocalValue); // Update the global variable
            Debug.Log($"{VariableName} in S_GlobalVars updated to {LocalValue}");
        }
        else
        {
            Debug.LogError($"Variable '{VariableName}' not found or is not of type bool in S_GlobalVars.");
        }
    }
}
