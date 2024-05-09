using System;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class DataMngr : MonoBehaviour
{
    public Player player = new Player();

    [HideInInspector] public int MotorPrice = 28699;
    [HideInInspector] public int JeepPrice = 88799;

    private static readonly byte[] key = new byte[16] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF, 0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10 };
    private static readonly byte[] iv = new byte[16] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF, 0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10 };

    private void Awake()
    {
        string filePath1 = Application.persistentDataPath + "/playerData.json";
        if (!System.IO.File.Exists(filePath1))
        {
            SaveMyData();
        }
        else
        {
            LoadMyData();
        }
    }

    public void SaveMyData()
    {
        SaveToDatabase();
    }

    public void LoadMyData()
    {
        LoadFromDatabase();
    }

    private void SaveToDatabase()
    {
        string playerData = JsonUtility.ToJson(player);
        EncryptData(Application.persistentDataPath + "/playerData.json", playerData);
        Debug.Log("Data has been saved.");
    }

    private void LoadFromDatabase()
    {
        string playerData = DecryptData(Application.persistentDataPath + "/playerData.json");
        player = JsonUtility.FromJson<Player>(playerData);
        Debug.Log("Data has been Loaded");
    }

    private void EncryptData(string filePath, string jsonData)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(jsonData);
                    }
                }

                File.WriteAllBytes(filePath, msEncrypt.ToArray());
            }
        }
    }

    private string DecryptData(string filePath)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(File.ReadAllBytes(filePath)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}

[System.Serializable]
public class Player //1st Data
{
    public int LevelIndex = 1;
    // public int PlayerTotalCoins;
    // public bool isMotorPurchase;
    // public bool isJeepPurchase;
}
 