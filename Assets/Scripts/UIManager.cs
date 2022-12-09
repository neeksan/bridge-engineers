using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button RoadButton;
    public Button WoodButton;
    public Text Text;
    public BarCreator BarCreator;
    public Slider BudgetSlider;
    public Text BudgetText;
    public Gradient myGradient;

    void Start()
    {
        RoadButton.onClick.Invoke();
    }

    public void Play()
    {
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ChangeBar(int barType)
    {
        if (barType == 0)
        {
            Text.transform.localPosition = new Vector3(-455f, 100f, 0f);
            BarCreator.BarToInstantiate = BarCreator.RoadBar;
        }
        else if (barType == 1)
        {
            Text.transform.localPosition = new Vector3(-370f, 100f, 0f);
            BarCreator.BarToInstantiate = BarCreator.WoodBar;
        }
    }
    public void UpdateBudgetUI(float CurrentBudget, float LevelBudget)
    {
        BudgetText.text = "$" + Mathf.FloorToInt(CurrentBudget).ToString();
        BudgetSlider.value = CurrentBudget / LevelBudget;
        BudgetSlider.fillRect.GetComponent<Image>().color = myGradient.Evaluate(BudgetSlider.value);
    }
}
