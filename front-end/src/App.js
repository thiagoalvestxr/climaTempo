import React, { useState, useEffect } from "react";
import toast from 'react-hot-toast';
import { Card, Spinner, SearchBar, Previsao } from './components';
import Constants from './utils/constants';
function App() {

  const [cidade, setCidade] = useState([]);
  const [cidades, setCidades] = useState([]);
  const [previsoes, setPrevisoes] = useState([]);

  const [cidadesMaisFrias, setCidadesMaisFrias] = useState([]);
  const [loadingCidadesMaisFrias, setLoadingCidadesMaisFrias] = useState(false);

  const [cidadesMaisQuentes, setCidadesMaisQuentes] = useState([]);
  const [loadingCidadesMaisQuentes, setLoadingCidadesMaisQuentes] = useState(false);

  function obtemCidades() {
    const url = Constants.API_URL_GET_CIDADES;

    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(cidades => {
        setCidades(cidades);
      })
      .catch((error) => {
        console.log(error.message);
        toast.error('Ocorreu um erro ao buscar cidades');
      });
  }

  function obtemPrevisoesCidade(id, cidade) {
    const url = `${Constants.API_URL_GET_PREVISAO_CIDADE}/${id}`;

    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(previsoes => {
        setCidade(cidade);
        setPrevisoes(previsoes);
      })
      .catch((error) => {
        console.log(error.message);
        toast.error('Ocorreu um erro ao buscar previsões');
      });
  }

  function obtemCidadesMaisFrias() {
    const url = Constants.API_URL_GET_PREVISOES_CIDADES_MAIS_FRIAS;
    setLoadingCidadesMaisFrias(true);

    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(previsoes => {
        setCidadesMaisFrias(previsoes);
        setLoadingCidadesMaisFrias(false);
      })
      .catch((error) => {
        console.log(error.message);
        toast.error('Ocorreu um erro ao buscar previsões');
        setLoadingCidadesMaisFrias(false);
      });
  }

  function obtemCidadesMaisQuentes() {
    const url = Constants.API_URL_GET_PREVISOES_CIDADES_MAIS_QUENTES;

    setLoadingCidadesMaisQuentes(true);

    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(previsoes => {
        setCidadesMaisQuentes(previsoes);
        setLoadingCidadesMaisQuentes(false);
      })
      .catch((error) => {
        console.log(error.message);
        toast.error('Ocorreu um erro ao buscar previsões');
        setCidadesMaisQuentes([]);
        setLoadingCidadesMaisQuentes(false);
      });
  }

  useEffect(() => {
    obtemCidades();
    obtemCidadesMaisFrias();
    obtemCidadesMaisQuentes();
  }, []);

  return (
    <div className="container">
      <div className="my-3">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <h1>Clima Tempo - Simples</h1>
        </div>
        <div className="row col-lg-12">
          {loadingCidadesMaisQuentes ? (
            <div className='col'>
              <Spinner message={'Carregando Cidades mais quentes...'} />
            </div>
          ) : (
            <Card titulo='Cidades mais quentes hoje' previsoes={cidadesMaisQuentes} />
          )}
          {loadingCidadesMaisFrias ? (
            <div className='col'>
              <Spinner message={'Carregando Cidades mais frias...'} />
            </div>
          ) : (
            <Card titulo='Cidades mais frias hoje' previsoes={cidadesMaisFrias} />
          )}
        </div>

        <div className="row col-lg-12">
          <SearchBar data={cidades} callback={obtemPrevisoesCidade} />
        </div>

        <div className="row col-lg-12">
          {previsoes.length > 0 &&
            <Previsao cidade={cidade} previsoes={previsoes} />
          }
        </div>

      </div>
    </div>
  );
}

export default App;
