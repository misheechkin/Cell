using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpSystem : MonoBehaviour
{
    private string helpURL = "D:\\project\\projectUnity\\Клетка\\Assets\\Sprafka.html";
    
    
    public void OpenHelp()
    {
        Application.OpenURL(helpURL);
    }
}
