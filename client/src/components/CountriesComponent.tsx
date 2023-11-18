import { useEffect, useLayoutEffect, useState } from "react";
import { Country } from "../interfaces/Country";
import Axios from 'axios';
import { Result } from "../interfaces/Result";
import "../styles/Countries.css"


interface Props {
  setResult: React.Dispatch<React.SetStateAction<Result | undefined>>
}

const CountriesComponent = ({ setResult }: Props) => {
  const [countries, setCountries] = useState<Country[]>([]);
  const [phoneNumber, setPhoneNumber] = useState("");
  const [countryCode, setCountryCode] = useState<string>("AU");
  const [errorMessage, setErrorMessage] = useState("");


  useEffect(() => {
      Axios.get("https://localhost:5000/api/Country").then((response) => {
        setCountries(response.data);
      })
  }, []);

  console.log(countries);
  
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
    <div className='validation_container'>
    <div className='countries'>
      <p>Country</p>
      <select className='countries' defaultValue={"AU"} onChange={(e) => {
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
        if (phoneNumber === "") {
          setErrorMessage("Phone Number is empty")
        }
        else {
            ValidateResult(phoneNumber, countryCode);
          }
          console.log(countryCode);
        }}>Verify</button>
        <p>{errorMessage}</p>
        
    </div>
  </div>
  )
}

export default CountriesComponent;