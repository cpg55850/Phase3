using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Animator startButton;
    public Animator settingsButton;
    public Animator settingsDialog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");   
    }
    public void OpenSetting()
    {
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        settingsDialog.SetBool("isHidden", false);
    }

    public void CloseSetting()
    {
        startButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        settingsDialog.SetBool("isHidden", true);
    }
}
