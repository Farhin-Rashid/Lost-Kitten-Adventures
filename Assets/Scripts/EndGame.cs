using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

public class EndGame : MonoBehaviour
{
    public GameObject endMessagePanel; // Drag the UI panel or text object here

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(ShowEndMessage());
        }
    }

    IEnumerator ShowEndMessage()
    {
        endMessagePanel.SetActive(true);
        yield return new WaitForSeconds(3f); // Display message for 3 seconds
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // If you're building the game
#endif
    }
}
