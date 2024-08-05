const numExercises = 5;

window.onload = function onPageLoad() {
    fillNumbers();
}

function checkAnswers() {

    let score = 0;

    for (let i = 1; i <= numExercises; i++) {

        let n1 = parseInt(document.getElementById(`num${i}1`).value); // 11, 12, 13

        let n2 = parseInt(document.getElementById(`num${i}2`).value);  // 21, 22, 23..

        let userAnswer = parseInt(document.getElementById(`anwser${i}`).value);

        let correctAnswer = 0;
        switch (i) {
            case 1:
                correctAnswer = n1 + n2;
                break;
            case 2:
                correctAnswer = n1 - n2;
                break;
            case 3:
                correctAnswer = n1 * n2;
                break;
            case 4:
                correctAnswer = Math.floor(n1 / n2);
                break;
            case 5:
                correctAnswer = n1 % n2;
                break;
        }

        let messageElement = document.getElementById(`msg${i}`);
        let iconElement = document.getElementById(`imgresult${i}`);


        if (userAnswer == correctAnswer) {
            messageElement.value = "Nice!"
            iconElement.setAttribute("src", "Images/v-mark.png");
            score += 1;
        }
        else {
            messageElement.value = "Almost, please try again"
            iconElement.setAttribute("src", "Images/x-mark.png");
        }
        messageElement.style.visibility = "visible";
        iconElement.style.visibility = "visible";
    }

    let elementScore = document.getElementById("score");
    elementScore.innerHTML = `You answered ${score} correct answers`;
    document.getElementById("score").style.visibility = "visible";
}


function fillNumbers() {
    for (let i = 1; i <= numExercises; i++) {

        document.getElementById(`num${i}1`).value = getRandomNumber(2); // 11, 12, 13
        document.getElementById(`num${i}2`).value = getRandomNumber(1);  // 21, 22, 23..
        document.getElementById(`anwser${i}`).value = "";

        // No need for let n1 = doc....
        //n1.value = getRandomNumber(2);
        //n2.value = getRandomNumber(1);
        //answer.value = "";

        document.getElementById(`msg${i}`).style.visibility = "hidden";
        document.getElementById(`imgresult${i}`).style.visibility = "hidden";
    }
    document.getElementById("score").style.visibility = "hidden";
}


function getRandomNumber(numDigits) {
    let num = parseInt(Math.random() * 10) + 1;

    if (numDigits == 2)
        num += 10;
    return num;
}
