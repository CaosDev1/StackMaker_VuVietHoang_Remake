using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject levelMenu;
    [SerializeField] private GameObject victoryUI;

    [SerializeField] private Button playerButton;
    [SerializeField] private Button closeMenuButton;

    
    
    private void OnEnable()
    {
        playerButton.onClick.AddListener(PlayeButton);
        closeMenuButton.onClick.AddListener(CloseMenuButton);
    }

    private void PlayeButton()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    private void CloseMenuButton()
    {
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
    }

    public void CloseLevelMenu()
    {
        levelMenu.SetActive(false);
    }

    public void VictoryUI()
    {
        victoryUI.SetActive(true);
    }
}
