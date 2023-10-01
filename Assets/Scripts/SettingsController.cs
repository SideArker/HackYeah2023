using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] GameObject resolutionTemplate;
    [SerializeField] GameObject resolutionTemplateParent;
    bool fullScreen = true;

    public void changeFullScreenState()
    {
        fullScreen = !fullScreen;
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, fullScreen);
    }


    void Start()
    {

        Resolution[] resolutions;
        resolutions = Screen.resolutions.Where(x => x.refreshRateRatio.value == Screen.currentResolution.refreshRateRatio.value).ToArray();

        for (int i = 0; i < resolutions.Length; i++)
        {
            GameObject currentObject;
            int objectResolutionWidth = resolutions[i].width;
            int objectResolutionHeight = resolutions[i].height;

            currentObject = Instantiate(resolutionTemplate, resolutionTemplateParent.transform);

            currentObject.GetComponent<TMP_Text>().text = $"{objectResolutionWidth}x{objectResolutionHeight}";

            Button currentBtn = currentObject.GetComponent<Button>();

            currentBtn.onClick.AddListener(() =>
            {

                Screen.SetResolution(objectResolutionWidth, objectResolutionHeight, fullScreen);
            });

            currentBtn.gameObject.SetActive(true);
        }
    }
}
