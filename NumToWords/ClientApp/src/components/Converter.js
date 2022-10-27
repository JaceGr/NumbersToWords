import React, {useState, useEffect} from 'react';

function Converter() {
  // Decimal number input holder
  const [numAmount, setNumAmount] = useState('');
  // Text output holder
  const [text, setText] = useState('');

  // Potential useEffect for validated at input. Other option is to not allow other keystrokes. 
  

  async function formSubmit(event) {
    event.preventDefault();

    const response = await fetch('conversion', {
      method: "POST",
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        inputNum: numAmount
      }),
    });
    console.log(response);
    // validate the response status here
    const data = await response.json();
    console.log(data.outputText);
    // validate outputText 
    setText(data.outputText);
  }
  
  return (
    <div className='converter'>
      <form className="amount-input-form" onSubmit={(event) => formSubmit(event)}>
        <input
          type='text'
          placeholder='Enter Amount'
          value={numAmount}
          onChange={(event) => {setNumAmount(event.target.value)}}
          className="amount-input-field"
        />
      </form>

      <p className="amount-output">{text}</p>
    </div>
  );
}



export default Converter;