using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    private void Update()
    {
        int seconds = (int) (60 * Time.deltaTime);

        GameInfos.gameTime += new GameTime(seconds);
    }

}
