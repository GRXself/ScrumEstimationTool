function createRoom() {
  $.ajax({
    url: '/Home/CreateRoom',
    type: 'POST',
    data: {
      roomId: $('#roomId-given').val(),
    },
    success: function (data) {
      redirectToHostOnCreateRoom(data);
    }
  });
}

function redirectToHostOnCreateRoom(joinResult) {
  if ('existRoom' in joinResult) {
    if (!joinResult.existRoom) {
      window.location.replace("/Host/Index");
    } else {
      alert("Room id exist! Please create another room!");
    }
  }
}

function joinRoom() {
  $.ajax({
    url: '/Home/JoinRoom',
    type: 'POST',
    data: {
      roomId: $('#roomId-join').val(),
    },
    success: function (data) {
      redirectToParticipantOnJoinRoom(data);
    }
  });
}

function redirectToParticipantOnJoinRoom(joinResult) {
  if (joinResult.hasOwnProperty('existRoom')) {
    if (joinResult.existRoom) {
      window.location.replace("/Participant/Index");
    } else {
      alert("Room id not exist! Please confirm your room id.");
    }
  }
}