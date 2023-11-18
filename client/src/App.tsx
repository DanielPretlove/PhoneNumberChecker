import React, { useEffect, useState } from 'react';
import './App.css';
import Axios from 'axios';
import { Country } from './interfaces/Country';
import { Result } from './interfaces/Result';

function App() {
  const [countries, setCountries] = useState<Country[]>([]);
  const [phoneNumber, setPhoneNumber] = useState("");
  const [countryCode, setCountryCode] = useState<string>("AU");
  const [result, setResult] = useState<Result>();

  useEffect(() => {
    Axios.get("https://localhost:5000/api/Country").then((response) => {
      setCountries(response.data);
    })
  }, []);

  function ValidateResult(phoneNumber: string, countryCode: string) {
    
    Axios.get(`https://localhost:5000/api/NumberChecker/ValidatePhoneNumber/${phoneNumber}/${countryCode}`, {
      headers: {
        'Access-Control-Allow-Origin': true
      },
    }).then((response) => {
      setResult(response.data);
    })
  }

  function CountryTypePhoneNumber(countryCode: string) {
    if (countryCode === "AU") {
      return "0412345678"
    }

    else if (countryCode === "NZ") {
      return "0212345678"
    }

    else {
      return "3912345678"
    }
  }

  return (
    <div className="App">
      <div className='container'>
        <div className='validation_container'>
          <div className='countries'>
            <p>Country</p>
            <select className='countries' onChange={(e) => {
                var selectedIndex = e.target.options.selectedIndex;
                setCountryCode(e.target.options[selectedIndex].getAttribute("data-key")!);
            }}>
              {countries.sort((a: Country, b: Country) => a.name.localeCompare(b.name)).map((value: Country, index) => {
                return (
                  <option key={index} data-key={value.countryCode}>{value.name}</option>
                )
              })}
          </select> 
          </div>
          <div className='phoneNumber'>
            <p>Phone Number</p>
            <input placeholder={CountryTypePhoneNumber(countryCode)} onChange={e => setPhoneNumber(e.target.value)} />
          </div>
          <div className='button_component'>
            <button className='verify' onClick={() => {
              ValidateResult(phoneNumber, countryCode);
              console.log(result?.isPossible);
            }}>Verify</button>
          </div>
        </div>
        <div className='result_container'>
          <div className='value isValid'>
            <p className='title'>Is Valid: </p>
            <p>{result?.isValid.toString()}</p>
          </div>
          <div className='value isPossible'>
            <p className='title'>Is Possible:</p>
            <p>{result?.isPossible.toString()}</p>
          </div>
          <div className='value phoneType'>
            <p className='title'>Phone Type:</p>
            <p>{result?.phoneType.toString()}</p>
          </div>
          <div className='value internationFormat'>
            <p className='title'>International Format:</p>
            <p>{result?.internationalFormat}</p>
          </div>
          <div className='button_component'>
            <button className='download_csv' onClick={() => {
                  
            }}>Download CSV</button>
          </div>
        </div>
    </div>        
    </div>
  );
}

export default App;
