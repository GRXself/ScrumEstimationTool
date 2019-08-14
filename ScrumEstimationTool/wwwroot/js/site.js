// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function LoadRoomInfo() {
    IsRoomIdEmpty();
    
    const roomId = Cookies.get('RoomId');
    $('#roomId-show').text(roomId);
}

function JoinRoom() {
    $.ajax({
        url: '/Home/JoinRoom',
        type: 'POST',
        data: {
            roomId: $('#roomId-join').val(),
        },
        success: function(data) {
            RedirectToParticipantOnJoinRoom(data)
        }
    });
}

function RedirectToParticipantOnJoinRoom(joinResult){
    if (joinResult.existRoom){
        window.location.replace("/Participant/Index");
    }
    else {
        alert("Room id not exist! Please confirm your room id.")
    }
}

/**
 * @return {boolean}
 */
function IsRoomIdEmpty() {
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