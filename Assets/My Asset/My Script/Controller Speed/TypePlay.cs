using System.Collections;
using System.Collections.Generic;
using Ring;
using UnityEngine;
using UnityEngine.EventSystems;

public class TypePlay : BaseClickButton//,IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    protected override void OnButtonClick()
    {
        var gamePlay = GameManager.Instance._gamePlay._gamePlay;
        gamePlay = (gamePlay == Game_Play.GamePlay.Non_Auto) ? Game_Play.GamePlay.Auto : Game_Play.GamePlay.Non_Auto;
        GameManager.Instance._gamePlay._gamePlay = gamePlay;
    }
}