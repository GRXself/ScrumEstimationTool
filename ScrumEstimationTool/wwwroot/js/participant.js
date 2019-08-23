function submitEstimation() {
  if (isRoomIdEmpty()) {
    return;
  }

  const participantName = $('#participant-name');
  const participantEstimation = $('#participant-estimation');
  if (participantName.val().trim().length === 0 || participantEstimation.text().trim().length === 0) {
    alert("Please give your name and estimation!");
  } else {
    $.ajax({
      url: '/Participant/SubmitEstimationPoint',
      type: 'POST',
      data: {
        Name: participantName.val(),
        PersonalEstimation: participantEstimation.text(),
      },
      success: function (data) {
        if (data.expired === true) {
          alert("Room not exist! Please reenter a room!");
        } else {
          alert("Submit Success");
        }
      }
    });
  }
}

function pokerCardOnSelected(pokerCard) {
  resetAllPokerCard();
  setEstimationOnClick(pokerCard);
  changeCSSOnSelected(pokerCard);
}

function setEstimationOnClick(pokerCard) {
  $('#participant-estimation').text($(pokerCard).text());
}

function changeCSSOnSelected(pokerCard) {
  $(pokerCard).removeClass("poker-card__body");
  $(pokerCard).addClass("poker-card--selected");
}

function resetAllPokerCard() {
  const allPokerCards = $(".poker-card__container > div");
  allPokerCards.removeClass("poker-card--selected");
  allPokerCards.addClass("poker-card__body");
}