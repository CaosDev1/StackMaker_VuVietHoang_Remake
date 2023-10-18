using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button levelButton;
    [SerializeField] private TextMeshProUGUI levelText;

    public void SetData(int id)
    {
        levelButton.onClick.AddListener(() =>
        {
            LevelButtonOnClick(id);
            UIManager.Instance.CloseLevelMenu();
        }
        );
    }
    
    public void LevelButtonOnClick(int id)
    {
        LevelManager.Instance.SpawnLevel(id);
    }

    public void SetText(string levelName)
    {
        levelText.text = levelName;
    }

}
