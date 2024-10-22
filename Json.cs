using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


[System.Serializable]
public class Data
{
    public float hp;   // 플레이어의 체력
    public float str;   // 플레이어의 공격력
    public float mp; // 플레이어의 마나 
    public int stage; // 스테이지 
    public int gold = 1; // 재화(골드)
    public int star = 1; // 재화(스타)
    public List<int> itemNumber = new List<int>();  //  저장할 아이템 고유번호를 담을 인트자료형 리스트 
    public Vector3 position; //플레이어의 위치 
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
        data.position = player.position;  // 플레이어 위치 저장
        //FindObjectOfType<Inventory>().SaveSlot();   // 인벤토리의 슬롯을 저장 

        // 저장 경로
        string path = Application.persistentDataPath + "/" + GameDataFileName;
        // 저장할 클래스를 json 형태로 전환 
        string saveDate = JsonUtility.ToJson(data, true);
        // json 형태로 전환된 문자열을 저장
        File.WriteAllText(path, saveDate); //파일을 생성하면서 값을 동시에 저장

    }

    public void Load()
    {
        // 불러오기 경로
        string path = Application.persistentDataPath + "/" + GameDataFileName;

        // 파일이 존재한다면 
        if (File.Exists(path))
        {
            // 문자열로 저장된 json 파일 읽어오기 
            string loadData = File.ReadAllText(path);
            // json을 클래스 형태로 전환 + 할당
            data = JsonUtility.FromJson<Data>(loadData);
            player.position = data.position; // 플레이어 위치 불러오기
            print(" 저장된 파일 불러오기 완료");
        }

        if (!File.Exists(path))
        {
            print("초기파일 불러오기 완료");
            FirstStart();
        }
    }

    public void DataDelete()
    {
        // 불러오기 경로
        string path = Application.persistentDataPath + "/" + GameDataFileName;

        if (File.Exists(path))
        {
            // 데이터 삭제 완료
            File.Delete(path);
        }
        else
        {
            return;
        }
    }

    public void FirstStart() // 초기 값으로 설정해주는 코드 
    {
        player.position = new Vector3(15.54f, 1.6826f, 371.0f);

        // 플레이어의 최초 스텟들 
        Json.instance.data.hp = 1000f;
        Json.instance.data.str = 70f;
        Json.instance.data.itemNumber.Clear(); // 아이템 초기화
    }


}