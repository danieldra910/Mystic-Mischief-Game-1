using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class SaveSystem 
{
    //Saves the player.
    public static void SavePlayer (PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player." + SceneManager.GetActiveScene().name;
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();

    }

        public static void SaveCamera (CameraLogic camera)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/camera." + SceneManager.GetActiveScene().name;
        FileStream stream = new FileStream(path, FileMode.Create);

        CameraData data = new CameraData(camera);

        formatter.Serialize(stream, data);
        stream.Close();

    }
    //Saves a checkpoint.
        public static void Checkpoint (PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.checkpoint" + SceneManager.GetActiveScene().name;
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static void SaveHats (PlayerHatLogic hat)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Hats" + SceneManager.GetActiveScene().name;
        FileStream stream = new FileStream(path, FileMode.Create);

        HatData data = new HatData(hat);

        formatter.Serialize(stream, data);
        stream.Close();
    }

        //Saves the enemies.
        public static void SaveEnemy (BaseEnemyAI enemy)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + enemy.name + SceneManager.GetActiveScene().name;
        FileStream stream = new FileStream(path, FileMode.Create);

        EnemyData data = new EnemyData(enemy);

        formatter.Serialize(stream, data);
        stream.Close();

    }
            //Saves the dragons.
        public static void SaveDragon (WaterDragonAi dragon)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + dragon.name + SceneManager.GetActiveScene().name;
        FileStream stream = new FileStream(path, FileMode.Create);

        DragonData data = new DragonData(dragon);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    //Saves the items.
    public static void SaveItem(Item item)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + item.name + SceneManager.GetActiveScene().name;
        FileStream stream = new FileStream(path, FileMode.Create);

        ItemData data = new ItemData(item);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    //Saves the inventory.
    public static void SaveInventory (Inventory inv)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Inventory." + SceneManager.GetActiveScene().name;
        FileStream stream = new FileStream(path, FileMode.Create);

        InventoryData data = new InventoryData(inv);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    //Loads the player.
    public static PlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player." + SceneManager.GetActiveScene().name;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

           PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
           return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    //Loads the hats.
    public static HatData LoadHats(PlayerHatLogic hat)
    {
        string path = Application.persistentDataPath + "/Hats" + SceneManager.GetActiveScene().name;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

           HatData data = formatter.Deserialize(stream) as HatData;
            stream.Close();
           return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

        public static CameraData LoadCamera ()
    {
        string path = Application.persistentDataPath + "/camera." + SceneManager.GetActiveScene().name;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

           CameraData data = formatter.Deserialize(stream) as CameraData;
            stream.Close();
           return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    //Loads a checkpoint.
        public static PlayerData LoadCheckpoint ()
    {
        string path = Application.persistentDataPath + "/player.checkpoint" + SceneManager.GetActiveScene().name;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

           PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
           return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    //Loads the enemies.
        public static EnemyData LoadEnemy (BaseEnemyAI enemy)
    {
        string path = Application.persistentDataPath + enemy.name + SceneManager.GetActiveScene().name;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

           EnemyData data = formatter.Deserialize(stream) as EnemyData;
            stream.Close();
           return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

        //Loads the dragon.
        public static DragonData LoadDragon (WaterDragonAi dragon)
    {
        string path = Application.persistentDataPath + dragon.name + SceneManager.GetActiveScene().name;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

           DragonData data = formatter.Deserialize(stream) as DragonData;
            stream.Close();
           return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    //Loads the items.
    public static ItemData LoadItem(Item item)
    {
        string path = Application.persistentDataPath + item.name + SceneManager.GetActiveScene().name;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ItemData data = formatter.Deserialize(stream) as ItemData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    //Loads the inventory.
    public static InventoryData LoadInventory ()
    {
        string path = Application.persistentDataPath + "/Inventory." + SceneManager.GetActiveScene().name;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

           InventoryData data = formatter.Deserialize(stream) as InventoryData;
            stream.Close();
           return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
