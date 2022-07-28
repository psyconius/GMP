using System.Linq;
using UnityEngine;

namespace GMP.Network
{
    [RequireComponent(typeof(PhotonView))]
    internal partial class GMPNetwork : Photon.PunBehaviour
    {
        public static GMPNetwork Instance { get; private set; }

        private void OnEnable()
        {
            photonView.viewID = 911; //Needs to be globally unique across all game / mods photon views
        }
        private void Start()
        {
            Instance = this;
        }

        [PunRPC]
        public void ReceivedNotificationRequest(string message)
        {
            var localPlayers = Global.Lobby.PlayersInLobby.Where(p => p.IsLocalPlayer);
            foreach (var p in localPlayers)
                p.ControlledCharacter.CharacterUI.ShowInfoNotification(message);
        }

        /// <summary>
        /// Sends the message to all online players
        /// </summary>
        /// <param name="requestPlayer"></param>
        /// <param name="message"></param>
        public void SendNotificationRequest(string message)
        {
            this.photonView.RPC(nameof(ReceivedNotificationRequest), PhotonTargets.All, message);
        }
    }
}
