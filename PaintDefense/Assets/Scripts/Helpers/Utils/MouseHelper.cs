using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers.Utils
{
    public class MouseHelper
    {
        public static Vector3 GetMousePos()
        {
            Vector3 MyMousePos = new Vector3();

            MyMousePos = new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0);
            MyMousePos = new Vector3((MyMousePos.x * 8.88f) / (Screen.width / 2), (MyMousePos.y * 5f) / (Screen.height / 2), 0);

            return MyMousePos;
        }
    }
}
