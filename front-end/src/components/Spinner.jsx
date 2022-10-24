import React from 'react';
import Loader from 'react-loader-spinner';

function Spinner({ message }) {
  return (
    <div>
      <Loader
        type="Circles"
        color="#00BFFF"
        height={50}
        width={200}
        className="m-5"
      />

      <p className="text-lg text-center px-2">{message}</p>
    </div>
  );
}

export default Spinner;
