using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Player player;
    Health plrHealth;
    [SerializeField] GameObject Slider;
    [SerializeField] GameObject Fill;
    [SerializeField] float lerpDuration = 0.5f;
    float colorFlashLerpDuration = 0.4f;
    [SerializeField] List<GameObject> ComboKeys;
    [SerializeField] GameObject codeObj;
    [SerializeField] GameObject CodeScreen;


    [SerializeField] Color colorFlash;


    int currentKey = 0;

    bool currentlyLerping = false;


    public void clearKeys()
    {
        foreach(GameObject key in ComboKeys)
        {
            key.transform.Find("Text").GetComponent<TMP_Text>().text = "";
            currentKey = 0;
        }
    }

    IEnumerator ColorFlash(TMP_Text text)
    {
        float timeElapsed = 0f;

        while (timeElapsed < colorFlashLerpDuration)
        {
            float t = timeElapsed / colorFlashLerpDuration;
            text.color = Color.Lerp(colorFlash, Color.white, t);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        text.color = Color.white;
    }




    public void openPanel(GameObject panel)
    {
        panel.SetActive(true);
    }    
    public void closePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void updateComboKeys(GameObject plr)
    {
        string comboString = plr.GetComponent<AttackCombo>().currentCombo;
        char[] array = comboString.ToCharArray();

        if(currentKey == plr.GetComponent<AttackCombo>().getMaxComboCount())
        {
            clearKeys();
            currentKey = 0;
        }

        TMP_Text text = ComboKeys[currentKey].transform.GetChild(0).GetComponent<TMP_Text>();

        text.text = array[currentKey].ToString();
        StartCoroutine(ColorFlash(text));
        

        currentKey++;
    }

    public void UpdateCode()
    {

    codeObj.transform.GetChild(0).GetComponent<TMP_Text>().text = CodeScreen.GetComponent<Code>().generatedCode;
    }

    void Start()
    {
        player = Player.Instance;
        plrHealth = player.GetComponent<Health>();
    }

    IEnumerator LerpHealth()
    {
        Slider slider = Slider.GetComponent<Slider>();

        float timeElapsed = 0f;

        while(timeElapsed < lerpDuration)
        {
            Fill.GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, plrHealth.getHealth() / plrHealth.getMaxHealth());

            float t = timeElapsed / lerpDuration;
            slider.value = Mathf.Lerp(slider.value, plrHealth.getHealth() / plrHealth.getMaxHealth(), t);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        slider.value = plrHealth.getHealth() / plrHealth.getMaxHealth();
        currentlyLerping = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(plrHealth.getHealth() < plrHealth.getMaxHealth() && currentlyLerping == false)
        {
            currentlyLerping = true;
            StartCoroutine(LerpHealth());
        }
    }
}
