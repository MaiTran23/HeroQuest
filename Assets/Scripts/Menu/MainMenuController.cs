using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
   public void PlayGame()
    {
        Application.LoadLevel("Gameplay");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BacktoMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void HelpButton()
    {
        Application.LoadLevel("Instruction");
    }
}
