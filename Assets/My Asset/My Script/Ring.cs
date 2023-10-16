using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace Ring
{
    
    [Serializable]
    public class Ui_Manager
    {
        [ChangeColorLabel(.7f, 1f, 1f)] public UpSpeed _speedVertical_UP;
        [ChangeColorLabel(.7f, 1f, 1f)] public DownSpeed _speedVertical_DOWN;
        
    }
    [Serializable]
    public class Game_Manager
    {
        [ChangeColorLabel(.7f, 1f, 1f)] public float _speedVertical_Horizontal;
        [ChangeColorLabel(.7f, 1f, 1f)] public bool isBosst = false; // Thêm biến mới để kiểm tra boost
    }
}

