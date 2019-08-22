function getCurrentEstimationResult() {
  if (isRoomIdEmpty()) {
    return;
  }

  $.ajax({
    url: '/Host/GetCurrentEstimationResult',
    type: 'POST',
    data: {},
    success: function (currentEstimationResult) {
      if (currentEstimationResult.expired === true) {
        alert("Session expired! Please create a new room.")
      } else {
        if (confirm(currentEstimationResult.count + " guys voted, show result?" +
          "\rCurrent participants: \r" + currentEstimationResult.participantsName)) {
          const estimationResultShowArea = $('#estimation-result-content');
          estimationResultShowArea.text("");
          for (const singleEstimation of currentEstimationResult.estimations) {
            estimationResultShowArea.append(singleEstimation + "<br/>");
          }
        }
      }
    }
  });
}

function reset() {
  if (confirm("Reset?")) {
    $.ajax({
      url: '/Host/ResetEstimation',
      type: 'POST',
      data: {},
      success: function (resetResult) {
        $('#estimation-result-content').text("Estimation Refreshed.");
      }
    });
  }
}

function copySharedLink() {
  /* Get the text field */
  const copyText = $('#room-link');

  /* Select the text field */
  copyText.select();

  /* Copy the text inside the text field */
  document.execCommand("copy");
}