// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function loadRoomInfo() {
  isRoomIdEmpty();

  const roomId = Cookies.get('RoomId');
  $('#roomId-show').text(roomId);
}

function loadRoomShareLink() {
  let hostName = window.location.hostname;
  if (window.location.port) {
    hostName += ":" + window.location.port;
  }
  const sharedLink = "https://" + hostName + "/Participant/JoinRoom/?roomId=" + Cookies.get('RoomId');
  $('#room-link').val(sharedLink);
}

function loadParticipantName() {
  $('#participant-name').val(Cookies.get('UserName'));
}

function loadHostPage() {
  loadRoomInfo();
  loadRoomShareLink();
}

function loadParticipantPage() {
  loadRoomInfo();
  loadParticipantName();
}


/**
 * @return {boolean}
 */
function isRoomIdEmpty() {
  const roomId = Cookies.get('RoomId');

  if (!roomId) {
    const alertMessage = "Please join a room first!";
    alert(alertMessage);
    $('#roomId-show').text(alertMessage);
    window.location.replace("/Home");
    return true;
  }

  return false;
}