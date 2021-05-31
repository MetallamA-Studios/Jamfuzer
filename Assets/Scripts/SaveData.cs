using System.Collections;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private static SaveData _current;
    public static SaveData current
    {
        get
        {
            if (_current == null)
            {
                _current = new SaveData();
            }

            return _current;
        }
        set
        {
            if(value != null)
            {
                _current = value;
            }
        }
    }

    public PlayerProfile profile;


    public void OnLoadGame()
    {
        current = (SaveData)SerializationManager.Load
                       (Application.persistentDataPath + "/saves/" + current.profile.playerName + ".save");
    }

    public void OnSaveGame()
    {
        SerializationManager.Save(current.profile.playerName, this);
    }
}
