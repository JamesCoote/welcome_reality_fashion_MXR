using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarSwapper : MonoBehaviour
{
    public string[] avatarNames;
    private int currentName = 0;

    public Text label;

    public void OnClick() {

        currentName++;
        if (currentName >= avatarNames.Length)
        {
            currentName = 0;
        }
        
        AsteroidsGameManager.avatarName = avatarNames[currentName];
        label.text = "Current Avatar: " + AsteroidsGameManager.avatarName;
    }
}
