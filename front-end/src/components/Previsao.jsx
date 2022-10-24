import './Previsao.css';

function Previsao({ cidade, previsoes }) {
    return (
        <div className="my-3">
            <div className="col d-flex flex-column justify-content-center align-items-center">
                <h2>{`Clima para os próximos 7 dias para a cidade de ${cidade}`}</h2>
            </div>
            <div className="row col justify-content-center align-items-center" style={{ padding: 0, margin: 20 }}>
                {previsoes.map((item, index) => (
                    <div className="col" key={index} style={{ padding: 0 }}>
                        <div className='cardPrevisao'>
                            <div className='header'>
                                <p>{item.dataPrevisao}</p>
                                <p>{item.diaSemana}</p>
                            </div>
                            <div className='body'>
                                <p>{item.clima}</p>
                                <p>{`Mínima: ${item.temperaturaMinima}º`}</p>
                                <p>{`Máxima: ${item.temperaturaMaxima}º`}</p>
                            </div>
                        </div>

                    </div>
                ))}
            </div>
        </div>
    );
}

export default Previsao
