import React, { useEffect, useState } from 'react';
import './App.css';
import Axios from 'axios';
import { Country } from './interfaces/Country';
import { Result } from './interfaces/Result';

function App() {
  const [countries, setCountries] = useState<Country[]>([]);
  const [phoneNumber, setPhoneNumber] = useState("");
  const [countryCode, setCountryCode] = useState("AU");
  const [result, setResult] = useState([]);

  useEffect(() => {
    Axios.get("https://localhost:5000/api/Country").then((response) => {
      setCountries(response.data);
    })
  }, []);

  function GetCountry(country: Country) {
    Axios.get(`https:5000/api/Country/${country.countryCode}`).then((response) => {
      console.log(response.data);
    });
  }

  function ValidateResult(phoneNumber: string, countryCode: string) {
    
    Axios.get(`https://localhost:5000/api/NumberChecker/ValidatePhoneNumber/${phoneNumber}/${countryCode}`, {
      headers: {
        'Access-Control-Allow-Origin': true
      },
    }).then((response) => {
      setResult(response.data);
    })
  }

  return (
    <div className="App">
      <div className='container'>
        <div className='validation_container'>
          <div className='countries'>
            <p>Country</p>
            <select className='countries' onChange={(e) => {
              setCountryCode(e.currentTarget.value);
            }} value={countryCode}>
              {countries.sort((a: Country, b: Country) => a.name.localeCompare(b.name)).map((value: Country) => {
                return (
                  <option key={value.countryCode}>{value.name}</option>
                )
              })}
          </select> 
          </div>
          <div className='phoneNumber'>
            <p>Phone Number</p>
            <input onChange={e => setPhoneNumber(e.target.value)} />
          </div>
          <div className='button_component'>
            <button className='verify' onClick={() => {
              ValidateResult(phoneNumber, countryCode);
            }}>Verify</button>
          </div>
        </div>
        <div className='result_container'>
          <div className='value isValid'>
            <p className='title'>Is Valid: </p>
            <p>True</p>
          </div>
          <div className='value isPossible'>
            <p className='title'>Is Valid:</p>
            <p>True</p>
          </div>
          <div className='value phoneType'>
            <p className='title'>Is Valid:</p>
            <p>True</p>
          </div>
          <div className='value internationFormat'>
            <p className='title'>Is Valid:</p>
            <p>True</p>
          </div>
          <div className='button_component'>
            <button className='download_csv'>Download CSV</button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
