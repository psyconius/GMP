using System.Linq;
using UnityEngine;

namespace GMP.Network
{
    // Required to send a message to all players(for dice roll)
    [RequireComponent(typeof(PhotonView))]
    internal partial class GMPNetwork : Photon.PunBehaviour
    {
        public static GMPNetwork Instance { get; private set; }

        private void OnEnable()
        {
            photonView.viewID = 920; //gothiska reserved ID
        }
        private void Start()
        {
            Instance = this;
        }

        [PunRPC]
        public void ReceivedNotificationRequest(string message)
        {
            var dice = ResourcesPrefabManager.Instance.GetItemPrefab(GMPItems.DICE);
            var localPlayers = Global.Lobby.PlayersInLobby.Where(p => p.IsLocalPlayer);
            foreach (var p in localPlayers)
                p.ControlledCharacter.CharacterUI.ShowInfoNotification(message, dice);
        }

        /// <summary>
        /// Sends the message to all online players(applies dice icon)
        /// </summary>
        /// <param name="requestPlayer"></param>
        /// <param name="message"></param>
        public void SendNotificationRequest(string message)
        {
            this.photonView.RPC(nameof(ReceivedNotificationRequest), PhotonTargets.All,  message);
        }
    }
}
