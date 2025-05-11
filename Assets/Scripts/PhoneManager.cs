using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneManager : MonoBehaviour
{
    [System.Serializable]
    public class Contact
    {
        public string name;
        [Range(1, 10)] public int affection = 1;
        public Button button;
        public TMP_Text affectionText;
    }

    [Header("Runtime refs")]
    public CanvasGroup phoneGroup;     // drag PhoneBody here
    public Contact[] contacts = new Contact[6];

    //[Header("Hot‑key")]
    //public KeyCode toggleKey = KeyCode.P;

    void Awake()
    {
        // wire the buttons once
        foreach (var c in contacts)
            c.button.onClick.AddListener(() => OnContactPressed(c));

       RefreshUI();
       ShowPhone();
        //HidePhone();                    // start closed
    }

    void Update()
    {
        //if (Input.GetKeyDown(toggleKey))
        //    TogglePhone();
    }

    // --- helpers ----------------------------------------------------------

    void TogglePhone() { if (phoneGroup.alpha < 0.5f) ShowPhone(); else HidePhone(); }
    void ShowPhone() { phoneGroup.alpha = 1; phoneGroup.interactable = phoneGroup.blocksRaycasts = true; Time.timeScale = 0; }
    void HidePhone() { phoneGroup.alpha = 0; phoneGroup.interactable = phoneGroup.blocksRaycasts = false; Time.timeScale = 1; }

    void OnContactPressed(Contact c)
    {
        if (c.affection < 10) c.affection++;
        RefreshUI();
    }

    void RefreshUI()
    {
        foreach (var c in contacts)
            c.affectionText.text = $"Affection: {c.affection}/10";
    }
}
