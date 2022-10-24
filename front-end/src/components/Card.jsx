import React from "react";

import './Card.css';

const Card = ({ titulo, previsoes }) => {
  return (
    <div className="card col" style={{ padding: 0, margin: 20 }}>
      <table className="table">
        <thead className="thead-dark">
          <tr>
            <th scope="col">{titulo}</th>
            <th scope="col"></th>
          </tr>
        </thead>
        <tbody>
          {previsoes.map((item, index) => (
            <tr key={index}>
              <td>{`${item.cidade}/${item.uf}`}</td>
              <td style={{ textAlign: "right" }}>
                {
                  `Máx: ${item.temperaturaMaxima}ºC`
                }
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default Card
