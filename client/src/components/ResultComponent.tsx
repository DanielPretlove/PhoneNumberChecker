import { useEffect, useState } from "react";
import { CSVLink } from "react-csv";
import { Result } from "../interfaces/Result";
import "../styles/Results.css"

interface Props {
  result: Result | undefined;
}

const ResultComponet = ({result}: Props) => {
  const [errorMessage, setErrorMessage] = useState("");
  
  const headers = [
    {label: "isValid", key: "result.isValid"},
    {label: "isPossible", key: "result.isPossible"},
    {label: "PhoneType", key: "result.phoneType"},
    {label: "internationFormat", key: "result.internationFormat"},
  ]

  const data = [
    {
      result: {
        isValid: result?.isValid,
        isPossible: result?.isPossible,
        phoneType: result?.phoneType,
        internationFormat: result?.internationalFormat
      }
    },
  ]
  

  useEffect(() => {
    if (result?.isValid === true) {
      setErrorMessage("");
    }
  }, [result])

  return (
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
        {result?.isValid === true ? 
          <CSVLink data={data} headers={headers} filename='PhoneNumberChecker' target='_blank'>
          <button className='download_csv'>Download CSV</button>
          </CSVLink> : <button className='download_csv' onClick={() => {
              setErrorMessage("Phone Number is not valid")
        }}>Download CSV</button>
      }
        <p className="error">{errorMessage}</p>
      </div>
  </div>
  )

}

export default ResultComponet;