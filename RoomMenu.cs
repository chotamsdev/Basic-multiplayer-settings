using UnityEngine.UIElements;
using UnityEngine;
using Photon.Pun;

public class RoomMenu : MonoBehaviour
{

    private Button _starGameBtn;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        Label roomName = root.Q<Label>("roomName");
        roomName.text = PhotonNetwork.CurrentRoom.Name + " room was Created";

        _starGameBtn = root.Q<Button>("StartGameBtn");
        _starGameBtn.clicked += StartGameBtnOnClicked;

        if (!PhotonNetwork.IsMasterClient)
            _starGameBtn.SetEnabled(false);
    }

    private void StartGameBtnOnClicked()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
