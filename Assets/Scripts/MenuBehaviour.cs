using TMPro;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField] GameObject currentSetting;
    [SerializeField] GameObject currentIndicator;
    [SerializeField] Color activeColor;
    [SerializeField] Color inactiveColor;


    public void Hover(GameObject setting)
    {
        currentSetting.GetComponent<TMP_Text>().color = inactiveColor;
        currentSetting.GetComponent<TMP_Text>().fontStyle = FontStyles.Normal;

        currentSetting = setting;
        currentSetting.GetComponent<TMP_Text>().color = activeColor;
        currentSetting.GetComponent<TMP_Text>().fontStyle = FontStyles.Italic;

        currentIndicator.SetActive(false);
        currentIndicator = setting.transform.Find("Indicator").gameObject;
        currentIndicator.SetActive(true);
    }


    void updateControls(GameObject panel)
    {
        currentSetting.GetComponent<TMP_Text>().color = inactiveColor;
        currentSetting.GetComponent<TMP_Text>().fontStyle = FontStyles.Normal;
        currentSetting = panel.GetComponent<PanelSettings>().defaultSetting;
        currentSetting.GetComponent<TMP_Text>().color = activeColor;
        currentSetting.GetComponent<TMP_Text>().fontStyle = FontStyles.Italic;

        currentIndicator.SetActive(false);
        currentIndicator = panel.GetComponent<PanelSettings>().defaultIndicator;
        currentIndicator.SetActive(true);
    }

    public void OpenPanel(GameObject panel)
    {
        updateControls(panel);

        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }



    public void Exit()
    {
    }
}
