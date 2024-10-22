using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


[System.Serializable]
public class Data
{
    public float hp;   // �÷��̾��� ü��
    public float str;   // �÷��̾��� ���ݷ�
    public float mp; // �÷��̾��� ���� 
    public int stage; // �������� 
    public int gold = 1; // ��ȭ(���)
    public int star = 1; // ��ȭ(��Ÿ)
    public List<int> itemNumber = new List<int>();  //  ������ ������ ������ȣ�� ���� ��Ʈ�ڷ��� ����Ʈ 
    public Vector3 position; //�÷��̾��� ��ġ 
}



public class Json : MonoBehaviour
{
    public Data data;
    static public Json instance;
    public Transform player;
    string GameDataFileName = "GameData.json";
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        data.position = player.position;  // �÷��̾� ��ġ ����
        //FindObjectOfType<Inventory>().SaveSlot();   // �κ��丮�� ������ ���� 

        // ���� ���
        string path = Application.persistentDataPath + "/" + GameDataFileName;
        // ������ Ŭ������ json ���·� ��ȯ 
        string saveDate = JsonUtility.ToJson(data, true);
        // json ���·� ��ȯ�� ���ڿ��� ����
        File.WriteAllText(path, saveDate); //������ �����ϸ鼭 ���� ���ÿ� ����

    }

    public void Load()
    {
        // �ҷ����� ���
        string path = Application.persistentDataPath + "/" + GameDataFileName;

        // ������ �����Ѵٸ� 
        if (File.Exists(path))
        {
            // ���ڿ��� ����� json ���� �о���� 
            string loadData = File.ReadAllText(path);
            // json�� Ŭ���� ���·� ��ȯ + �Ҵ�
            data = JsonUtility.FromJson<Data>(loadData);
            player.position = data.position; // �÷��̾� ��ġ �ҷ�����
            print(" ����� ���� �ҷ����� �Ϸ�");
        }

        if (!File.Exists(path))
        {
            print("�ʱ����� �ҷ����� �Ϸ�");
            FirstStart();
        }
    }

    public void DataDelete()
    {
        // �ҷ����� ���
        string path = Application.persistentDataPath + "/" + GameDataFileName;

        if (File.Exists(path))
        {
            // ������ ���� �Ϸ�
            File.Delete(path);
        }
        else
        {
            return;
        }
    }

    public void FirstStart() // �ʱ� ������ �������ִ� �ڵ� 
    {
        player.position = new Vector3(15.54f, 1.6826f, 371.0f);

        // �÷��̾��� ���� ���ݵ� 
        Json.instance.data.hp = 1000f;
        Json.instance.data.str = 70f;
        Json.instance.data.itemNumber.Clear(); // ������ �ʱ�ȭ
    }


}