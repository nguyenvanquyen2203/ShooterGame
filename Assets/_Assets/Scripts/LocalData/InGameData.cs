using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameData : MonoBehaviour
{
    private static InGameData instance;
    public static InGameData Instance { get { return instance; } }
    public List<GunInformation> gunEquips;
    public List<SpecialWeaponData> specialItemEquips;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Set this as the Singleton instance
            instance = this;
            // Optional: Make the GameObject persistent across scenes
            DontDestroyOnLoad(this.gameObject);
        }

    }
    public SpecialWeaponData GetSpWeapon(int index) => specialItemEquips[index]; 
}
