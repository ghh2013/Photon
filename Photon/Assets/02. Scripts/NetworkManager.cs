using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    public Text infoText;
    public Button connectButton;

    string gameVersion = "1";

    private void Awake()
    {
        Screen.SetResolution(800, 600, FullScreenMode.Windowed);
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
        infoText.text = "마스터 서버에 접속중";
        connectButton.interactable = false;
    }

    public override void OnConnectedToMaster()
    {
        infoText.text = "온라인 마스터서버와 연결됨";
        connectButton.interactable = true;
        
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        connectButton.interactable = false;
        infoText.text = "온라인 마스터서버와 연결 실패";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void OnConnect()
    {
        connectButton.interactable = false;
        if(PhotonNetwork.IsConnected)
        {
            infoText.text = "랜덤방에 접속";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            infoText.text = "온라인 마스터서버와 연결 실패";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnJoinedRoom()
    {
        infoText.text = "방 참가 성공했음";
        PhotonNetwork.LoadLevel("GameScene");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        infoText.text = "빈방이 없으니 새로운 방 생성중";
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 }) ;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
