using System.Collections;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    #region Singleton
    private static SaveData _sd_current;
    public static SaveData sd_current
    {
        get
        {
            if (_sd_current == null)
            {
                _sd_current = new SaveData();
            }

            return _sd_current;
        }
        set
        {
            if(value != null)
            {
                _sd_current = value;
            }
        }
    }
    #endregion

    #region Public Variables
    public PlayerProfile p_profile;

    #endregion

}
