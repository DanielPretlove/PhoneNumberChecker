import { useState } from 'react';
import './App.css';
import { Result } from "./interfaces/Result";
import ResultCompoent from './components/ResultComponent';
import CountriesComponent from './components/CountriesComponent';


function App() {
  const [result, setResult] = useState<Result>();

  return (
    <div className="App">
      <div className='container'>
        <CountriesComponent setResult={setResult} />
        <ResultCompoent result={result} />
    </div>        
    </div>
  );
}

export default App;
