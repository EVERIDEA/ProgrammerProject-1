using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Everidea.Editor {

    public class DatabaseEditor : EditorWindow
    {

        [MenuItem("Everidea/Database")]
        public static void ShowWindow()
        {
            GetWindow<DatabaseEditor>("Database");
        }

    }
}
