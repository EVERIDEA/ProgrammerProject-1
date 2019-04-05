using System.Collections;
using UnityEngine;
using UnityEditor;

namespace Everidea.EditorDB {

    public class DatabaseEditor : EditorWindow
    {
        Texture2D headerSectionTexture;
        Texture2D playerDataTexture;
        Texture2D enemyDataTexture;
        Texture2D weaponDataTexture;

        Color headerSectionColor = new Color(140f / 255f, 140f / 255f, 140f / 255f, 1f);

        Rect headerSection;
        Rect playerSection;
        Rect enemySection;
        Rect weaponSection;

        static Everidea.CoreData.PlayerData playerData;
        static Everidea.CoreData.EnemyData enemyData;
        static Everidea.CoreData.WeaponData weaponData;

        public static Everidea.CoreData.PlayerData PlayerInfo { get { return playerData; } }
        public static Everidea.CoreData.EnemyData EnemyInfo { get { return enemyData; } }
        public static Everidea.CoreData.WeaponData WeaponInfo { get { return weaponData; } }

        [MenuItem("Everidea/Database")]
        static void OpenWindow()
        {
            DatabaseEditor editor = (DatabaseEditor)GetWindow(typeof(DatabaseEditor));
            editor.minSize = new Vector2(600, 300);
            editor.Show();
        }

        private void OnEnable()
        {
            InitTextures();
            InitData();
        }
        
        public static void InitData()
        {
            playerData = (Everidea.CoreData.PlayerData)ScriptableObject.CreateInstance(typeof(Everidea.CoreData.PlayerData));
            enemyData = (Everidea.CoreData.EnemyData)ScriptableObject.CreateInstance(typeof(Everidea.CoreData.EnemyData));
            weaponData = (Everidea.CoreData.WeaponData)ScriptableObject.CreateInstance(typeof(Everidea.CoreData.WeaponData));

        }

        void InitTextures()
        {
            headerSectionTexture = new Texture2D(1, 1);
            headerSectionTexture.SetPixel(0, 0, headerSectionColor);
            headerSectionTexture.Apply();


            playerDataTexture = new Texture2D(1, 1);
            playerDataTexture.SetPixel (0, 0, new Color(170 / 255f, 170 / 255f, 170 / 255f, 1f));
            playerDataTexture.Apply();


            enemyDataTexture = new Texture2D(1, 1);
            enemyDataTexture.SetPixel(0, 0, new Color(190 / 255f, 190 / 255f, 190 / 255f, 1f));
            enemyDataTexture.Apply();

            weaponDataTexture = new Texture2D(1, 1);
            weaponDataTexture.SetPixel(0, 0, new Color(170 / 255f, 170 / 255f, 170 / 255f, 1f));
            weaponDataTexture.Apply();
        }

        void OnGUI()
        {
            DrawLayouts();
            DrawHeader();
            DrawPlayerSettings();
            DrawEnemySettings();
            DrawWeaponSettings();
        }
        void DrawLayouts()
        {
            headerSection.x = 0;
            headerSection.y = 0;
            headerSection.width = Screen.width;
            headerSection.height = 50;

            playerSection.x = 0;
            playerSection.y = 50;
            playerSection.width = Screen.width / 3f;
            playerSection.height = Screen.width - 50;

            enemySection.x = Screen.width / 3f;
            enemySection.y = 50;
            enemySection.width = Screen.width / 3f;
            enemySection.height = Screen.width - 50;

            weaponSection.x = (Screen.width / 3f) * 2;
            weaponSection.y = 50;
            weaponSection.width = Screen.width / 3f;
            weaponSection.height = Screen.width - 50;

            GUI.DrawTexture(headerSection, headerSectionTexture);
            GUI.DrawTexture(playerSection, playerDataTexture);
            GUI.DrawTexture(enemySection, enemyDataTexture);
            GUI.DrawTexture(weaponSection, weaponDataTexture);
        }
        void DrawHeader()
        {
            GUILayout.BeginArea(headerSection);

            GUILayout.Label("Database Editor");

            GUILayout.EndArea();
        }
        void DrawPlayerSettings()
        {
            GUILayout.BeginArea(playerSection);

            GUILayout.Label("Player Database");

            GUILayout.BeginHorizontal();
            GUILayout.Label("Id");
            playerData.Id = EditorGUILayout.TextField(playerData.Id);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Name");
            playerData.Name = EditorGUILayout.TextField(playerData.Name);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Class Type");
            playerData.ClassType = (Types.PlayerClassType)EditorGUILayout.EnumPopup(playerData.ClassType);
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Set Database"))
            {
                GeneralSettings.OpenWindow(GeneralSettings.SettingsType.PLAYER);
            }

            GUILayout.EndArea();
        }
        void DrawEnemySettings()
        {
            GUILayout.BeginArea(enemySection);

            GUILayout.Label("Enemy Database");

            GUILayout.BeginHorizontal();
            GUILayout.Label("Id");
            enemyData.Id = EditorGUILayout.TextField(enemyData.Id);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Name");
            enemyData.Name = EditorGUILayout.TextField(enemyData.Name);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Class Type");
            enemyData.EnemyType = (Types.EnemyType)EditorGUILayout.EnumPopup(enemyData.EnemyType);
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Set Database"))
            {
                GeneralSettings.OpenWindow(GeneralSettings.SettingsType.ENEMY);
            }

            GUILayout.EndArea();
        }

        void DrawWeaponSettings()
        {
            GUILayout.BeginArea(weaponSection);

            GUILayout.Label("Weapon Database");

            GUILayout.BeginHorizontal();
            GUILayout.Label("Id");
            weaponData.WeaponId = EditorGUILayout.TextField(weaponData.WeaponId);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Name");
            weaponData.WeaponName = EditorGUILayout.TextField(weaponData.WeaponName);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Class Type");
            weaponData.Type = (Types.AttackType)EditorGUILayout.EnumPopup(weaponData.Type);
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Set Database"))
            {
                GeneralSettings.OpenWindow(GeneralSettings.SettingsType.WEAPON);
            }

            GUILayout.EndArea();
        }
    }

    public class GeneralSettings : EditorWindow
    {
        public enum SettingsType
        {
            PLAYER,
            ENEMY,
            WEAPON
        }

        static SettingsType dataSettings;
        static GeneralSettings window;

        public static void OpenWindow(SettingsType type)
        {
            dataSettings = type;
            window = (GeneralSettings)GetWindow(typeof(GeneralSettings));
            window.minSize = new Vector2(250, 250);
            window.Show();
        }

        private void OnGUI()
        {
            switch (dataSettings)
            {
                case SettingsType.PLAYER:
                    DrawPlayerSettings();
                    break;
                case SettingsType.ENEMY:
                    break;
                case SettingsType.WEAPON:
                    DrawWeaponSettings();
                    break;
            }
        }

        void DrawPlayerSettings()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Level");
            DatabaseEditor.PlayerInfo.Level = EditorGUILayout.IntField(DatabaseEditor.PlayerInfo.Level);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Health");
            DatabaseEditor.PlayerInfo.Health = EditorGUILayout.FloatField(DatabaseEditor.PlayerInfo.Health);
            GUILayout.EndHorizontal();
        }
        void DrawEnemySettings()
        {

        }
        void DrawWeaponSettings()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Critical Chance");
            DatabaseEditor.WeaponInfo.CriticalChance = EditorGUILayout.Slider(DatabaseEditor.WeaponInfo.CriticalChance, 0 , 100);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Lifesteal Chance");
            DatabaseEditor.WeaponInfo.LifestealChance = EditorGUILayout.Slider(DatabaseEditor.WeaponInfo.LifestealChance, 0 , 100);
            GUILayout.EndHorizontal();
        }
    }
}
