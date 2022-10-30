import React from 'react';
import Converter from './components/Converter';
import './custom.css';


function App() {

    return (
      <div className='body'>
        <h1 className="title">Numbers To Words Convertor</h1>
        <p className="description">Welcome to this number to word convertor that will convert dollar amounts into words.
          <br/>Please enter a dollar amount below $10,000,000,000,000.00
        </p>
        <Converter />
      </div>
    );
}

export default App;