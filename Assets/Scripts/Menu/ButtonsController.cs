using UnityEditor;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject OptionsPanel;
    [SerializeField] private GameObject pluginPanel;
    public void ToggleOptions()
    {
        if (OptionsPanel.activeInHierarchy)
        {
            OptionsPanel.SetActive(false);
            MenuPanel.SetActive(true);
        }
        else
        {
            OptionsPanel.SetActive(true);
            MenuPanel.SetActive(false);
        }
    }

    public void TogglePlugin()
    {
        if (pluginPanel.activeInHierarchy)
        {
            pluginPanel.SetActive(false);
            MenuPanel.SetActive(true);
        }
        else
        {
            pluginPanel.SetActive(true);
            MenuPanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}