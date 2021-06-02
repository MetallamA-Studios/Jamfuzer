using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager
{
    public void OnLoadGame()
    {
        SaveData.sd_current = (SaveData)SerializationManager.Load
                       (Application.persistentDataPath + "/saves/" + SaveData.sd_current.p_profile.s_playerName + ".save");
    }

    public void OnSaveGame()
    {
        SerializationManager.Save(SaveData.sd_current.p_profile.s_playerName, this);
    }
}
