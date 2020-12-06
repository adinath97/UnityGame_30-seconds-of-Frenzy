using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static void LoadStartMenu()
    {
        SceneManager.LoadScene("START_MENU");
    }

    public static void LoadGameScene()
    {
        SceneManager.LoadScene("Game_Scene");
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void IntroAndInstructions()
    {
        SceneManager.LoadScene("INTRO_INSTRUCTIONS");
    }

    public static void IntroAndInstructions2()
    {
        SceneManager.LoadScene("INTRO_INSTRUCTIONS_2");
    }
}
