using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager
{
    public void OnLoadGame()
    {
        SaveData.current = (SaveData)SerializationManager.Load
                       (Application.persistentDataPath + "/saves/" + SaveData.current.profile.playerName + ".save");
    }

    public void OnSaveGame()
    {
        SerializationManager.Save(SaveData.current.profile.playerName, this);
    }
}
