using UnityEngine;

public class StartPopupManager : MonoBehaviour
{
    public GameObject popupPanel; // Assign the StartPopup panel in Unity

    void Start()
    {
        popupPanel.SetActive(true); // Show the popup when the game starts
    }

    public void ClosePopup()
    {
        popupPanel.SetActive(false); // Hide the popup when button is clicked
    }
}