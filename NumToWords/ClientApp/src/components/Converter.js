import React, { useState } from 'react';

function Converter() {
  // Decimal number input holder
  const [numInput, setNumAmount] = useState('');
  // Text output holder
  const [text, setText] = useState('');
  // Whether there is an error in the input field that has been submitted.
  const [error, setError] = useState(false);
  // Error message to be shown
  const [errorText, setErrorText] = useState('');

  /**
   * Form submission functionality to validate input, 
   * send to server-side and display result returned.
   * @param event To prevent default form behaviour
   * @returns 
   */
  async function formSubmit(event) {
    event.preventDefault();

      if(!validateInput(numInput)) {
        return;
      }

    const response = await fetch('conversion', {
      method: "POST",
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        inputNum: numInput
      }),
    });

    // validate the response status here
    if(response.status !== 200) {
      showError(`${response.status} Error`);
      return;
    }
    const data = await response.json();
    if (data.error !== "" && data.error != null) {
      showError(data.error);
      return;
    }

    setText(data.outputText);
    setError(false);
  }

  /**
   * Validating the input number on the clientside. 
   * To be called each time that the number is submitted.
   * @param input the string input that represents the number to convert.
   * @returns True if valid number, False otherwise.
   */
  function validateInput(input) {
    // Check for empty string
    if(input == null || input === '') {
      showError('Please enter a non-empty number.');
      return false;
    }

    //Check special case of only decimal
    if(input === ".") {
      showError("Please enter a valid number.");
      return false;
    }
    
    let dollars;

    // Ensure is a valid number
    try {
      let dollarCent = input.split(".");

      // Ensure maximum 1 decimal place 
      if(dollarCent.length > 2) {
        showError("Please only use one decimal place.");
        return false;
      } 
      // Ensure both sides of the decimal are digits, allowing either side to be empty
      for(let i=0; i<dollarCent.length; i++) {
        if(isNaN(dollarCent[i]) || (isNaN(parseFloat(dollarCent[i])) && dollarCent[i] !== "")) {
            showError("Please ensure only valid digits are used.");
            return false;
        }
      } 
      dollars = dollarCent[0];

    } catch {
      showError("Please provide the number in the format $xxx,xxx.xx");
      return false;
    }

    // Ensure number is not too large
    if(dollars >= 10000000000000 || input < 0) {
      showError("Apologies, this number is not in the valid range for this tool");
      return false;
    }

    return true;
  }

  /**
   * Display given error string on the front-end.
   * @param error The error string to display.
   */
  function showError(error) {
    setErrorText(error);
    setError(true);
  }
  
  return (
    <div className='converter'>
      <form className="amount-input-form" onSubmit={(event) => formSubmit(event)}>
        <input
          type='text'
          placeholder='Enter Amount'
          value={numInput}
          onChange={(event) => {setNumAmount(event.target.value)}}
          className="amount-input-field"
        />
      </form>

      { !error && <p className="amount-output">{text}</p> }
      { error && <p className="error-message">{errorText}</p> }
    </div>
  );
}

export default Converter;